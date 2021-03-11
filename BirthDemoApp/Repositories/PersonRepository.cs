using Microsoft.EntityFrameworkCore;
using PregnancyDemoApp.AppDbContext;
using PregnancyDemoApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancyDemoApp.Repositories
{
    public sealed class PersonRepository : UniqueEntityRepository<Person>, IPersonRepository
    {
        private readonly PregnancyDbContext context;
        public PersonRepository(PregnancyDbContext con) : base(con, con.Persons) { context = con; }
    }
}
