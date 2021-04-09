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

        public PregnancyRepository(PregnancyDbContext con) : base(con, con.Pregnancies) { context = con; }

        public async Task<IReadOnlyCollection<Pregnancy>> GetPregnanciesByMotherId(int motherId)
        {
            var query = context.Pregnancies.AsNoTracking().Where(o => o.Id == motherId);
            return await query.ToListAsync();
            //return await context.Pregnancies.Where(o => o.MotherId == motherId).ToListAsync();
        }

        public async Task<IReadOnlyCollection<Pregnancy>> GetPregnanciesByObstetricianId(int obId)
        {
            var query = context.Pregnancies.AsNoTracking().Where(o => o.Id == obId);
            return await query.ToListAsync();
            //return await context.Pregnancies.Where(o => o.ObstetricianId == obId).ToListAsync();
        }

        public int GetPregnancyByBirthId(int birthId)
        {
            var bb = context.Pregnancies.FirstOrDefault(x => x.ChildbirthId == birthId);
            if(bb is null)
            {
                //Not ideal
                return 0;
            }
            return bb.MotherId;
        }

        public int GetPregnancyByMotherId(int momId)
        {
            var oo = context.Pregnancies.FirstOrDefault(x => x.MotherId == momId);
            if(oo is null)
            {
                //Not ideal
                return 0;
            }
            return oo.ObstetricianId;
        }
    }
}