using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment2_Server.Persistence;
using Assignment2_Server.Models;

namespace Assignment2_Server.Data
{
    public class AdultsData : IAdultsData
    {
        private IList<Adult> adults;
        private FileContext fileContext;

        public AdultsData()
        {
            fileContext = new FileContext();
            adults = fileContext.Adults;
        }
        public async Task<IList<Adult>> GetAdults()
        {
            return adults;
        }

        public async Task<Adult> AddAdult(Adult adult)
        {
            await Task.Run(() =>
            {
                int max = adults.Max(adult => adult.Id);
                adult.Id = (++max);
                adults.Add(adult);
                fileContext.SaveChanges();
            });
            return adult;
        }

        public async Task RemoveAdult(string firstName, string lastName)
        {
            await Task.Run(() =>
            {
                Adult toRemove = adults.First(t => t.FirstName.Equals(firstName) && t.LastName.Equals(lastName));
                adults.Remove(toRemove);
            });
            fileContext.SaveChanges();
        }

        public async Task Update(Adult adult)
        {
            await Task.Run(() =>
            {
                Adult toUpdate = adults.First(t =>
                    t.Id == adult.Id);
                toUpdate.JobTitle= adult.JobTitle;
                toUpdate.Age = adult.Age;
                toUpdate.Height = adult.Height;
                toUpdate.Id = adult.Id;
                toUpdate.Sex = adult.Sex;
                toUpdate.Weight = adult.Weight;
                toUpdate.EyeColor = adult.EyeColor;
                toUpdate.FirstName = adult.FirstName;
                toUpdate.LastName = adult.LastName;
                toUpdate.HairColor = adult.HairColor;
            });
            fileContext.SaveChanges();
        }

        public async Task<Adult> Get(int id)
        {
            Console.WriteLine(1);
            return adults.FirstOrDefault(t => t.Id == id);
        }
    }
}