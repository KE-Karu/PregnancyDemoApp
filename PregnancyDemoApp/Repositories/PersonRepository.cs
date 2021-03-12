using PregnancyDemoApp.AppDbContext;
using PregnancyDemoApp.Models;

namespace PregnancyDemoApp.Repositories
{
    public sealed class PersonRepository : UniqueEntityRepository<Person>, IPersonRepository
    {
        public PersonRepository(PregnancyDbContext con) : base(con, con.Persons) { }
    }
}
