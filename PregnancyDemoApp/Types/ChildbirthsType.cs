using GraphQL.Types;
using PregnancyDemoApp.Models;
using PregnancyDemoApp.Repositories;
using System.Collections.Generic;

namespace PregnancyDemoApp.Types
{
    public class ChildbirthsType : ObjectGraphType<Childbirth>
    {
        public ChildbirthsType(IPregnancyRepository pregnancyRepository, IPersonRepository personRepository, IObstetricianRepository obstetricianRepository)
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Childbirth Id");
            Field(x => x.Notes).Description("Birth notes");
            Field(x => x.PregnancyId, type: typeof(IdGraphType)).Description("Pregnancy Id");
            FieldAsync<PregnanciesType, Pregnancy>("pregnancy", resolve: ctx =>
            {
                return pregnancyRepository.GetById(ctx.Source.PregnancyId);
            });
            Field(x => x.StartDate).Description("Starting Date of Childbirth");
            Field(x => x.EndDate).Description("Ending Date of Childbirth");

            FieldAsync<ListGraphType<PersonsType>, IReadOnlyCollection<Person>>(
                 "motherInfo", "returns mother info",
                 resolve: context =>
                 {
                     return pregnancyRepository.GetMotherByPregnancyId(context.Source.PregnancyId);
                 });

            FieldAsync<ListGraphType<ObstetriciansType>, IReadOnlyCollection<Obstetrician>>(
                 "obstetricianInfo", "returns obstetrician info",
                 resolve: context =>
                 {
                     return obstetricianRepository.GetObstetricianByPregnancyId(context.Source.PregnancyId);
                 });
        }
    }
}
