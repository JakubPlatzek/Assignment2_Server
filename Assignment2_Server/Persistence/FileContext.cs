using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Assignment2_Server.Models;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Assignment2_Server.Persistence
{
    public class FileContext : IFileContext
    {
        public IList<Family> Families { get; private set; }
        public IList<Adult> Adults { get; private set; }
        
        public IList<User> Users { get; private set; }

        private readonly string familiesFile = "Database/families.json";
        private readonly string adultsFile = "Database/adults.json";
        private readonly string usersFile = "Database/users.json";

        public FileContext()
        {
            Families = File.Exists(familiesFile) ? ReadData<Family>(familiesFile) : new List<Family>();
            Adults = File.Exists(adultsFile) ? ReadData<Adult>(adultsFile) : new List<Adult>();
            Users = File.Exists(usersFile) ? ReadData<User>(usersFile) : new List<User>();
            Console.WriteLine(Adults.ToString());
        }

        public IList<T> ReadData<T>(string s)
        {
            using (var jsonReader = File.OpenText(s))
            {
                //return JsonSerializer.Deserialize<List<T>>(jsonReader.ReadToEnd());
                JsonSerializerSettings settings = new() { TypeNameHandling = TypeNameHandling.All };
                return JsonConvert.DeserializeObject<List<T>>(jsonReader.ReadToEnd(), settings);
            }
        }

        public void SaveChanges()
        {
            // storing families
            string jsonFamilies = JsonSerializer.Serialize(Families, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            using (StreamWriter outputFile = new StreamWriter(familiesFile, false))
            {
                outputFile.Write(jsonFamilies);
            }

            // storing adults
            string jsonAdults = JsonSerializer.Serialize(Adults, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            using (StreamWriter outputFile = new StreamWriter(adultsFile, false))
            {
                outputFile.Write(jsonAdults);
            }
            
            // storing users
            string jsonUsers = JsonSerializer.Serialize(Users, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            using (StreamWriter outputFile = new StreamWriter(usersFile, false))
            {
                outputFile.Write(jsonUsers);
            }
        } 
    }
}