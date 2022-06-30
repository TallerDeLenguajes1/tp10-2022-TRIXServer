
using System.Text.Json.Serialization;

public class root 
{
    [JsonPropertyName("civilizations")]
    public List<civilization> civilization { get; set; }
    
}