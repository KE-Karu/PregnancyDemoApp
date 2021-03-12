using PregnancyDemoApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PregnancyDemoApp.Repositories
{
    public interface IObstetricianRepository : IRepository<Obstetrician>
    {
        Task<IReadOnlyCollection<Obstetrician>> GetObstetricianByPregnancyId(int pregnancyId);
    }
}
