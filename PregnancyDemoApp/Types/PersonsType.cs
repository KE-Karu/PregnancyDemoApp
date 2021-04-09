using GraphQL.Types;
using PregnancyDemoApp.Models;
using PregnancyDemoApp.Repositories;
using System.Collections.Generic;

namespace PregnancyDemoApp.Types
{
    public class PersonsType : ObjectGraphType<Person>
    {
        public PersonsType(IPregnancyRepository pregnancyRepository, IObstetricianRepository obstetricianRepository)
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Persons Id");
            Field(x => x.NatIdNr).Description("Persons Unique National Identification Number");
            Field(x => x.FirstName).Description("Persons First Name");
            Field(x => x.LastName).Description("Persons Last Name");
            Field(x => x.Address).Description("Persons Current Address");
            Field(x => x.Sex).Description("Gender of the Person");
            //Field(x => x.DateOfBirth).Description("Persons Date of Birth");
            //Field(x => x.DateOfDeath, nullable: true).Description("Persons Date of Death");

            FieldAsync<ListGraphType<PregnanciesType>, IReadOnlyCollection<Pregnancy>>(
                "personalPregnancies", "returns list of all personal pregnancies",
                resolve: async context =>
                {
                    return await pregnancyRepository.GetPregnanciesByMotherId(context.Source.Id);
                });

            FieldAsync<ListGraphType<ObstetriciansType>, IReadOnlyCollection<Obstetrician>>(
                "personalObstetricians", "returns list of all personal obstetricians",
                resolve: async context =>
                {;
                    int oo = pregnancyRepository.GetPregnancyByMotherId(context.Source.Id);
                    return await obstetricianRepository.GetObstetricianById(oo);
                });
        }
    }
}
