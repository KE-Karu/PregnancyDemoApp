using GraphQL.Types;
using PregnancyDemoApp.Models;
using PregnancyDemoApp.Repositories;

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
            Field(x => x.ChildbirthId, type: typeof(IdGraphType)).Description("Birth Id");
            FieldAsync<ChildbirthsType, Childbirth>("birth", resolve: ctx =>
            {
                return birthRepository.GetById(ctx.Source.ChildbirthId);
            });
            Field(x => x.StartDate, nullable:true).Description("Starting Date of Pregnancy");
            Field(x => x.EndDate, nullable: true).Description("Ending Date of Pregnancy");
            Field(x => x.DueDate).Description("Estimated Due Date");
        }
    }
}
