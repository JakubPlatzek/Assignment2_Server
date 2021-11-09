using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment2_Server.Models
{
    public class Job
    {
        [Key]
        public string JobTitle { get; set; }
        public int Salary { get; set; }
    }
}