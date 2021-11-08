using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment2_Server.Controllers;
using Assignment2_Server.Models;
using Assignment2_Server.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Assignment2_Server.Data
{
    public class UserService : IUserService
    {
        private IQueryable<User> users;
        private EFCContext _efcContext;

        public UserService()
        {
            _efcContext = new EFCContext();
            users = _efcContext.Users;
        }

        public async Task<User> AddUser(User user)
        {
            user.Registered = "true";
               await _efcContext.Users.AddAsync(user);
               await _efcContext.SaveChangesAsync();
               return user;
        }

       public async Task<User> ValidateUser(string userName, string password)
        {
            User first = _efcContext.Users.FirstOrDefaultAsync(user => user.UserName.Equals(userName) && user.Password.Equals(password)).Result;
            if (first == null)
            {
                throw new Exception("User not found");
            }

            if (!first.Password.Equals(password))
            {
                throw new Exception("Incorrect password");
            }
            return first;
        }
    }
}