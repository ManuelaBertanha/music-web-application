using System.Text.Json.Serialization;

namespace music_web_application.Model.Errors;

public class SpotifyErrorResponse
{
    [JsonPropertyName("error")]
    public SpotifyError SpotifyError { get; set; }
}