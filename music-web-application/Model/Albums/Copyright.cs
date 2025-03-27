using System.Text.Json.Serialization;

namespace music_web_application.Model.Albums;

public class Copyright
{
    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }
}