using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Assignment2_Server.Models {
public class Adult : Person {
    public Job Job { get; set; }
}
}