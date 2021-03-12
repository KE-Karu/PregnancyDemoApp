using GraphQL.Types;
using PregnancyDemoApp.Models;
using PregnancyDemoApp.Repositories;
using System.Collections.Generic;

namespace PregnancyDemoApp.Types
{
    public class PersonsType : ObjectGraphType<Person>
    {
        public PersonsType(IPregnancyRepository pregnancyRepository)
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Persons Id");
            Field(x => x.NatIdNr).Description("Persons Unique National Identification Number");
            Field(x => x.FirstName).Description("Persons First Name");
            Field(x => x.LastName).Description("Persons Last Name");
            Field(x => x.Address).Description("Persons Current Address");

            Field<GendersType>(nameof(Person.Gender));

            FieldAsync<ListGraphType<PregnanciesType>, IReadOnlyCollection<Pregnancy>>(
                "personalPregnancies", "returns list of all personal pregnancies",
                resolve: context =>
                {
                    return pregnancyRepository.GetPregnanciesByMotherId(context.Source.Id);
                });

            //FieldAsync<ListGraphType<ChildbirthsType>, IReadOnlyCollection<Childbirth>>(
            //    "personalBirths", "returns list of all personal childbirths",
            //    resolve: context =>
            //    {
            //        return personRepository.GetBirthByPersonId(context.Source.Id);
            //    });
        }
    }
}
