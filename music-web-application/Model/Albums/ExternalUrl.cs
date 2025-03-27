using System.Text.Json.Serialization;

namespace music_web_application.Model.Albums;

public class ExternalUrl
{
    [JsonPropertyName("spotify")]
    public string Spotify { get; set; }
}