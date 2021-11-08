using Assignment2_Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment2_Server.Persistence
{
    public class EFCContext: DbContext
    {
        public DbSet<Adult> Adults { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = C:/Users/jakub/RiderProjects/Assignment2_Server/Assignment2_Server/Database/EFC.db");
        }
    }
}