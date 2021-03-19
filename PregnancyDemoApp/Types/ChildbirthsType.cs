using GraphQL.Types;
using PregnancyDemoApp.Models;
using PregnancyDemoApp.Repositories;
using System.Collections.Generic;

namespace PregnancyDemoApp.Types
{
    public class ChildbirthsType : ObjectGraphType<Childbirth>
    {
        public ChildbirthsType(IPregnancyRepository pregnancyRepository, IPersonRepository personRepository)
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Childbirth Id");
            Field(x => x.Notes).Description("Birth notes");
            Field(x => x.StartDate, nullable: true).Description("Starting Date of Childbirth");
            Field(x => x.EndDate, nullable: true).Description("Ending Date of Childbirth");

            FieldAsync<ListGraphType<PersonsType>, IReadOnlyCollection<Person>>(
                 "mothersInfo", "returns mother personal info",
                 resolve: async context =>
                 {
                     int vv = pregnancyRepository.GetPregnancyByBirthId(context.Source.Id);
                     return await personRepository.GetPersonById(vv);
                 });
        }
    }
}
