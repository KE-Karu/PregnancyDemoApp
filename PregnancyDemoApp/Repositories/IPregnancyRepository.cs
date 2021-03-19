using PregnancyDemoApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PregnancyDemoApp.Repositories
{
    public interface IPregnancyRepository : IRepository<Pregnancy>
    {
        Task<IReadOnlyCollection<Pregnancy>> GetPregnanciesByMotherId(int id);
        Task<IReadOnlyCollection<Pregnancy>> GetPregnanciesByObstetricianId(int id);
        int GetPregnancyByMotherId(int id);
        int GetPregnancyByBirthId(int id);
    }
}
