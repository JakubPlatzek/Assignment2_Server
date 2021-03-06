using System.Threading.Tasks;
using Assignment2_Server.Models;

namespace Assignment1.Data
{
    public interface IUserService
    {
        Task<User> ValidateUser(string userName, string password);
        Task<User> AddUser(User user);
    }
}