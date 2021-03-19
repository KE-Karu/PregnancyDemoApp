using PregnancyDemoApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PregnancyDemoApp.Repositories
{
    public interface IPersonRepository : IRepository<Person>
    {
        Task<IReadOnlyCollection<Person>> GetPersonById(int id);
    }
}
