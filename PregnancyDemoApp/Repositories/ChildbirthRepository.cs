using Microsoft.EntityFrameworkCore;
using PregnancyDemoApp.AppDbContext;
using PregnancyDemoApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancyDemoApp.Repositories
{
    public sealed class ChildbirthRepository : UniqueEntityRepository<Childbirth>, IChildbirthRepository
    {
        public ChildbirthRepository(PregnancyDbContext con) : base(con, con.Childbirths) { }

    }
}
