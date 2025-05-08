using System.Text.Json.Serialization;

namespace music_web_application.Model.Errors;

public class SpotifyError
{
    [JsonPropertyName("status")]
    public int Status { get; set; }
    
    [JsonPropertyName("message")]
    public string Message { get; set; }
}