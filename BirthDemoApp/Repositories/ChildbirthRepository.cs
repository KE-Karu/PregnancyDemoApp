using PregnancyDemoApp.AppDbContext;
using PregnancyDemoApp.Models;

namespace PregnancyDemoApp.Repositories
{
    public sealed class ChildbirthRepository : UniqueEntityRepository<Childbirth>, IChildbirthRepository
    {
        public ChildbirthRepository(PregnancyDbContext c) : base(c, c.Childbirths) { }
    }
}
