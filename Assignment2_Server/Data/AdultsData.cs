using System.Linq;
using System.Threading.Tasks;
using Assignment2_Server.Persistence;
using Assignment2_Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment2_Server.Data
{
    public class AdultsData : IAdultsData
    {
        private IQueryable<Adult> Adults;
        private EFCContext _efcContext;

        public AdultsData()
        {
            _efcContext = new EFCContext();
            Adults = _efcContext.Adults;
        }
        public async Task<IQueryable<Adult>> GetAdults()
        {
            return _efcContext.Adults;
        }

        public async Task<Adult> AddAdult(Adult adult)
        {
            /*int max = Adults.Max(adult => adult.Id);
                adult.Id = (++max);*/
                await _efcContext.Adults.AddAsync(adult);
            await _efcContext.SaveChangesAsync();
            return adult;
        }

        public async Task RemoveAdult(string firstName, string lastName)
        {
            Adult toRemove = await _efcContext.Adults.FirstAsync(t => t.FirstName.Equals(firstName) && t.LastName.Equals(lastName));
                _efcContext.Adults.Remove(toRemove); 
                await _efcContext.SaveChangesAsync();
        }

        public async Task Update(Adult adult)
        {
            Adult toUpdate = await _efcContext.Adults.FirstAsync(t =>
                    t.Id == adult.Id);
                toUpdate.AdultJob= adult.AdultJob;
                toUpdate.Age = adult.Age;
                toUpdate.Height = adult.Height;
                toUpdate.Id = adult.Id;
                toUpdate.Sex = adult.Sex;
                toUpdate.Weight = adult.Weight;
                toUpdate.EyeColor = adult.EyeColor;
                toUpdate.FirstName = adult.FirstName;
                toUpdate.LastName = adult.LastName;
                toUpdate.HairColor = adult.HairColor;
                await _efcContext.SaveChangesAsync();
        }

        public async Task<Adult> Get(int id)
        {
            return _efcContext.Adults.FirstOrDefault(t => t.Id == id);
        }
    }
}