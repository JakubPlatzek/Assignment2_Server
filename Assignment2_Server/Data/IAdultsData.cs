using System.Collections.Generic;
using System.Threading.Tasks;
using Assignment2_Server.Models;

namespace Assignment2_Server.Data
{
    public interface IAdultsData
    {
        Task<IList<Adult>> GetAdults();
        Task<Adult> AddAdult(Adult adult);
        Task RemoveAdult(string firstName, string lastName);
        Task Update(Adult adult);
        Adult Get(int id);
    }
}