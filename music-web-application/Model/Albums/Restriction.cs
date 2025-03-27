using System.Text.Json.Serialization;

namespace music_web_application.Model.Albums;

public class Restriction
{
    [JsonPropertyName("reason")]
    public string Reason { get; set; }
}