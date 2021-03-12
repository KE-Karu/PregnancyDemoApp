using Microsoft.EntityFrameworkCore;
using PregnancyDemoApp.AppDbContext;
using PregnancyDemoApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancyDemoApp.Repositories
{
    public sealed class PregnancyRepository : UniqueEntityRepository<Pregnancy>, IPregnancyRepository
    {
        private readonly PregnancyDbContext context;
        //private List<Pregnancy> preg;

        public PregnancyRepository(PregnancyDbContext con) : base(con, con.Pregnancies) { context = con; }
        
        public async Task<IReadOnlyCollection<Person>> GetMotherByPregnancyId(int motherId)
        {
            return await context.Persons.Where(o => o.Id == motherId).ToListAsync();
        }

        public async Task<IReadOnlyCollection<Pregnancy>> GetPregnanciesByMotherId(int motherId)
        {
            return await context.Pregnancies.Where(o => o.MotherId == motherId).ToListAsync();
        }

        public async Task<IReadOnlyCollection<Pregnancy>> GetPregnanciesByObstetricianId(int obId)
        {
            return await context.Pregnancies.Where(o => o.ObstetricianId == obId).ToListAsync();
        }
    }
}