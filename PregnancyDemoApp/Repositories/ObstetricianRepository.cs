using Microsoft.EntityFrameworkCore;
using PregnancyDemoApp.AppDbContext;
using PregnancyDemoApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancyDemoApp.Repositories
{
    public sealed class ObstetricianRepository : UniqueEntityRepository<Obstetrician>, IObstetricianRepository
    {
        private readonly PregnancyDbContext context;
        public ObstetricianRepository(PregnancyDbContext con) : base(con, con.Obstetricians) { context = con; }

        public async Task<IReadOnlyCollection<Obstetrician>> GetObstetricianByPregnancy(int obId)
        {
            //Obstetrician obs = new Obstetrician();
            //var selected = obs.Pregnancies.Where(x => x.Id == obId);
            //return selected;
            return await context.Obstetricians.Where(o => o.Id == obId).ToListAsync();
        }
    }
}
