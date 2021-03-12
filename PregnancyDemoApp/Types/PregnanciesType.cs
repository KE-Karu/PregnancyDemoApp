using GraphQL.Types;
using PregnancyDemoApp.Models;
using PregnancyDemoApp.Repositories;
using System.Collections.Generic;

namespace PregnancyDemoApp.Types
{
    public class PregnanciesType: ObjectGraphType<Pregnancy>
    {
        public PregnanciesType(IPersonRepository personRepository, IObstetricianRepository obstetricianRepository, IChildbirthRepository birthRepository)
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Pregnancy Id");
            Field(x => x.MotherId, type: typeof(IdGraphType)).Description("Mother Id");
            FieldAsync<PersonsType, Person>("mother", resolve: ctx =>
            {
                return personRepository.GetById(ctx.Source.MotherId);
            });
            Field(x => x.ObstetricianId, type: typeof(IdGraphType)).Description("Obstetrician Id");
            FieldAsync<ObstetriciansType, Obstetrician>("obstetrician", resolve: ctx =>
            {
                return obstetricianRepository.GetById(ctx.Source.ObstetricianId);
            });
            Field(x => x.StartDate).Description("Starting Date of Pregnancy");
            Field(x => x.EndDate).Description("Ending Date of Pregnancy");
            Field(x => x.DueDate).Description("Estimated Due Date");

            FieldAsync<ListGraphType<ChildbirthsType>, IReadOnlyCollection<Childbirth>>(
                "relatedBirth", "returns related birth info",
                resolve: context =>
                {
                    return birthRepository.GetBirthByPregnancyId(context.Source.Id);
                });
        }
    }
}
