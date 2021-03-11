using PregnancyDemoApp.Models;
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
                new Person{ NatIdNr = "39502114232", FirstName = "Tõnu", LastName=" Vaarikas", Address = "Maardu 25", Gender = Gender.Male},
                new Person{ NatIdNr = "49403136515", FirstName = "Mari", LastName=" Maasikas", Address = "Lepa 32", Gender = Gender.Female}
            };
            foreach (Person p in persons)
            {
                context.Persons.Add(p);
            }
            context.SaveChanges();


        }
    }
}
