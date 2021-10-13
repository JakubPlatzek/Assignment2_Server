using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Assignment2_Server.Data
{
    public interface IAdultsData
    {
        Task<IList<Adult>> GetAdults();
        Adult AddAdult(Adult adult);
        void RemoveAdult(string firstName, string lastName);
        void Update(Adult adult);
        Adult Get(int id);
    }
}