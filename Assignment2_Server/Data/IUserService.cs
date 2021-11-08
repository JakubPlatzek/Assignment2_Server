using System.Threading.Tasks;
using Assignment2_Server.Models;

namespace Assignment2_Server.Data
{
    public interface IUserService
    {
        Task<User> ValidateUser(string userName, string password);
        Task<User> AddUser(User user);
    }
}