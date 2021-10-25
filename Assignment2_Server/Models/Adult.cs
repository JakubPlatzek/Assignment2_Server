using System.Text.Json.Serialization;

namespace Assignment2_Server.Models {
public class Adult : Person {
    [JsonPropertyName("jobTitle")]
    public Job JobTitle { get; set; }
    
    
}
}