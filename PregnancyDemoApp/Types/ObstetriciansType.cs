using GraphQL.Types;
using PregnancyDemoApp.Models;
using PregnancyDemoApp.Repositories;
using System.Collections.Generic;

namespace PregnancyDemoApp.Types
{
    public class ObstetriciansType : ObjectGraphType<Obstetrician>
    {
        public ObstetriciansType(IPregnancyRepository pregnancyRepository, IPersonRepository personRepository)
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Obestrician Id");
            Field(x => x.PersonId, type: typeof(IdGraphType)).Description("Person Id");
            FieldAsync<PersonsType, Person>("obestrician", resolve: async ctx =>
            {
                return await personRepository.GetById(ctx.Source.PersonId);
            });

            FieldAsync<ListGraphType<PregnanciesType>, IReadOnlyCollection<Pregnancy>>(
                "guidedPregnancies", "returns list of all personally guided pregnancies",
                resolve: async context =>
                {
                    return await pregnancyRepository.GetPregnanciesByObstetricianId(context.Source.Id);
                });

        }
    }
}
