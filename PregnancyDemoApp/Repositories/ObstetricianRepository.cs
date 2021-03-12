using PregnancyDemoApp.AppDbContext;
using PregnancyDemoApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PregnancyDemoApp.Repositories
{
    public sealed class ObstetricianRepository : UniqueEntityRepository<Obstetrician>, IObstetricianRepository
    {
        private readonly PregnancyDbContext context;
        public ObstetricianRepository(PregnancyDbContext con) : base(con, con.Obstetricians) { context = con; }

        public Task<IReadOnlyCollection<Obstetrician>> GetObstetricianByPregnancyId(int pregnancyId)
        {
            throw new System.NotImplementedException();
        }
    }
}
