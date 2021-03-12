using PregnancyDemoApp.AppDbContext;
using PregnancyDemoApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PregnancyDemoApp.Repositories
{
    public sealed class PregnancyRepository : UniqueEntityRepository<Pregnancy>, IPregnancyRepository
    {
        private readonly PregnancyDbContext context;
        public PregnancyRepository(PregnancyDbContext con) : base(con, con.Pregnancies) { context = con; }
        
        public Task<IReadOnlyCollection<Person>> GetMotherByPregnancyId(int pregnancyId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IReadOnlyCollection<Pregnancy>> GetPregnanciesByMotherId(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IReadOnlyCollection<Pregnancy>> GetPregnanciesByObstetricianId(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
