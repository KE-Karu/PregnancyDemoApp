using PregnancyDemoApp.AppDbContext;
using PregnancyDemoApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PregnancyDemoApp.Repositories
{
    public sealed class ChildbirthRepository : UniqueEntityRepository<Childbirth>, IChildbirthRepository
    {
        private readonly PregnancyDbContext context;
        public ChildbirthRepository(PregnancyDbContext con) : base(con, con.Childbirths) { context = con; }

        public Task<IReadOnlyCollection<Childbirth>> GetBirthByPregnancyId(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
