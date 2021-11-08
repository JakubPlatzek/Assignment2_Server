using System.ComponentModel.DataAnnotations;

namespace Assignment2_Server.Models
{
    public class User
    {
        [Key]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Registered { get; set; }
    }
}