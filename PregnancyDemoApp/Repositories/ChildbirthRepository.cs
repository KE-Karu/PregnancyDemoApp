using PregnancyDemoApp.AppDbContext;
using PregnancyDemoApp.Models;

namespace PregnancyDemoApp.Repositories
{
    public sealed class ChildbirthRepository : UniqueEntityRepository<Childbirth>, IChildbirthRepository
    {
        public ChildbirthRepository(PregnancyDbContext con) : base(con, con.Childbirths) { }

    }
}
