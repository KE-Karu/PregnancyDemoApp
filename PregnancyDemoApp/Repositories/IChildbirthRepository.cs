using PregnancyDemoApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PregnancyDemoApp.Repositories
{
    public interface IChildbirthRepository : IRepository<Childbirth>
    {
        //Siia meetod
        Task<IReadOnlyCollection<Childbirth>> GetBirthByPregnancyId(int id);
    }
}
