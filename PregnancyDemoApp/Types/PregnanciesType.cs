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
            Field(x => x.PersonId, type: typeof(IdGraphType)).Description("Mother Id");
            FieldAsync<PersonsType, Person>("mother", resolve: async ctx =>
            {
                return await personRepository.GetById(ctx.Source.PersonId);
            });
            Field(x => x.ObstetricianId, type: typeof(IntGraphType), nullable: true).Description("Obstetrician Id");
            FieldAsync<ObstetriciansType, Obstetrician>("obstetrician", resolve: async ctx =>
            {
                return await obstetricianRepository.GetById(ctx.Source.ObstetricianId);
            });
            //Field(x => x.ChildbirthId, type: typeof(IdGraphType)).Description("Birth Id");
            //FieldAsync<ChildbirthsType, Childbirth>("birth", resolve: async ctx =>
            //{
            //    return await birthRepository.GetById(ctx.Source.ChildbirthId);
            //});
            Field(x => x.DueDate).Description("Estimated Due Date");
        }
    }
}
