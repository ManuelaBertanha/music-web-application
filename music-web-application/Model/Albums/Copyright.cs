using System.Text.Json.Serialization;

namespace music_web_application.Model.Albums;

public class Copyright
{
    [JsonPropertyName("text")]
    private string _text { get; set; }

    [JsonPropertyName("type")]
    private string _type { get; set; }
}