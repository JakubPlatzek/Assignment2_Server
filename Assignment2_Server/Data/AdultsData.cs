using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment2_Server.Persistence;
using Models;

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
            Console.WriteLine(adults[1].FirstName);
            return adults;
        }

        public Adult AddAdult(Adult adult)
        {
            int max = adults.Max(adult => adult.Id);
            adult.Id = (++max);
            adults.Add(adult);
            fileContext.SaveChanges();
            return adult;
        }

        public void RemoveAdult(string firstName, string lastName)
        {
            Adult toRemove = adults.First(t => t.FirstName.Equals(firstName) && t.LastName.Equals(lastName));
            adults.Remove(toRemove);
            fileContext.SaveChanges();
        }

        public void Update(Adult adult)
        {
            Adult toUpdate = adults.First(t => t.FirstName.Equals(adult.FirstName) && t.LastName.Equals(adult.LastName));
            toUpdate.JobTitle.JobTitle = adult.JobTitle.JobTitle;
            toUpdate.Age = adult.Age;
            toUpdate.Height = adult.Height;
            toUpdate.Id = adult.Id;
            toUpdate.Sex = adult.Sex;
            toUpdate.Weight = adult.Weight;
            toUpdate.EyeColor = adult.EyeColor;
            toUpdate.FirstName = adult.FirstName;
            toUpdate.LastName = adult.LastName;
            toUpdate.HairColor = adult.HairColor;
            toUpdate.JobTitle.Salary = adult.JobTitle.Salary;
            fileContext.SaveChanges();
        }

        public Adult Get(int id)
        {
            return adults.FirstOrDefault(t => t.Id == id);
        }
    }
}