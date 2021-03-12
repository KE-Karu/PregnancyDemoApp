using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using PregnancyDemoApp.AppDbContext;
using PregnancyDemoApp.Models;
using PregnancyDemoApp.Repositories;
using System;
using System.Collections.Generic;

namespace PregnancyDemoApp.Types
{
    public class ChildbirthsType : ObjectGraphType<Childbirth>
    {
        public ChildbirthsType(IPregnancyRepository pregnancyRepository, IPersonRepository personRepository, IObstetricianRepository obstetricianRepository)
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Childbirth Id");
            Field(x => x.Notes).Description("Birth notes");
            Field(x => x.StartDate, nullable: true).Description("Starting Date of Childbirth");
            Field(x => x.EndDate, nullable: true).Description("Ending Date of Childbirth");

            //FieldAsync<ListGraphType<PersonsType>, IReadOnlyCollection<Person>>(
            //     "motherInfo", "returns mother info",
            //     resolve: context =>
            //     {

            //         Pregnancy aa = await mc.Pregnancies.FirstAsync(x => x.Id == context.Source.PregnancyId);

            //         using (var mc = con())
            //         {

            //             var o = pregnancyRepository.GetById(context.Source.PregnancyId);
            //         }
            //         return pregnancyRepository.GetMotherByPregnancyId(o.Result.MotherId);
            //     });

            //FieldAsync<ListGraphType<ObstetriciansType>, IReadOnlyCollection<Obstetrician>>(
            //     "obstetricianInfo", "returns obstetrician info",
            //     resolve: context =>
            //    {
            //        var o = pregnancyRepository.GetById(context.Source.PregnancyId);
            //        return obstetricianRepository.GetObstetricianByPregnancy(o.Result.ObstetricianId);
            //    });
        }
    }
}
