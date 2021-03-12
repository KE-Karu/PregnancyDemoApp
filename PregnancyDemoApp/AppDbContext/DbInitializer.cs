using PregnancyDemoApp.Models;
using System;
using System.Linq;

namespace PregnancyDemoApp.AppDbContext
{
    public class DbInitializer
    {
        public static void Initialize(PregnancyDbContext context)
        {
            if (context.Persons.Any())
            {
                return;
            }
            var persons = new Person[]
            {
                new Person{ NatIdNr = "34501234215 ", FirstName = "Ants", LastName= "Mustikas", Address = "Viru 10", Gender = Gender.Male},
                new Person{ NatIdNr = "39502114232", FirstName = "Tõnu", LastName= "Vaarikas", Address = "Maardu 25", Gender = Gender.Male},
                new Person{ NatIdNr = "49403136515", FirstName = "Mari", LastName= "Maasikas", Address = "Lepa 32", Gender = Gender.Female},
                new Person{ NatIdNr = "49502414215", FirstName = "Kati", LastName= "Sõstar", Address = "Sinivälja 46", Gender = Gender.Female}
            };
            foreach (Person p in persons)
            {
                context.Persons.Add(p);
            }
            context.SaveChanges();


            if (context.Obstetricians.Any())
            {
                return;
            }
            var obstetricians = new Obstetrician[]
            {
                new Obstetrician{ PersonId = 1},
                new Obstetrician{ PersonId = 2}
            };
            foreach (Obstetrician p in obstetricians)
            {
                context.Obstetricians.Add(p);
            }
            context.SaveChanges();


            if (context.Pregnancies.Any())
            {
                return;
            }
            var pregnancies = new Pregnancy[]
            {
                new Pregnancy{ MotherId = 3, ObstetricianId = 1, DueDate= DateTime.Parse("1-1-2022"), StartDate= DateTime.Parse("1-5-2021"), EndDate = DateTime.Parse("2-1-2022")},
                new Pregnancy{ MotherId = 4, ObstetricianId = 2, DueDate= DateTime.Parse("2-2-2022"), StartDate = DateTime.Parse("1-6-2021"), EndDate = null},
               
            };
            foreach (Pregnancy p in pregnancies)
            {
                context.Pregnancies.Add(p);
            }
            context.SaveChanges();



            if (context.Childbirths.Any())
            {
                return;
            }
            var childbirths = new Childbirth[]
            {
                new Childbirth{ PregnancyId = 1, Notes = "Some notes", StartDate= DateTime.Parse("1-1-2022"), EndDate = DateTime.Parse("2-1-2022")},
                new Childbirth{ PregnancyId = 2, Notes = "More notes", StartDate= null, EndDate = null},

            };
            foreach (Childbirth p in childbirths)
            {
                context.Childbirths.Add(p);
            }
            context.SaveChanges();
        }
    }
}
