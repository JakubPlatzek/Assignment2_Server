using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment2_Server.Models;

namespace Assignment2_Server.Data
{
    public interface IAdultsData
    {
        Task<IQueryable<Adult>> GetAdults();
        Task<Adult> AddAdult(Adult adult);
        Task RemoveAdult(string firstName, string lastName);
        Task Update(Adult adult);
        Task<Adult> Get(int id);
    }
}