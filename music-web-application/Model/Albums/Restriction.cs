using System.Text.Json.Serialization;

namespace music_web_application.Model.Albums;

public class Restriction
{
    [JsonPropertyName("reason")]
    private string _reason { get; set; }
}