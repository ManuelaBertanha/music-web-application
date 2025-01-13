using System.Text.Json.Serialization;

namespace music_web_application.Model.Albums;

public class Image
{
    [JsonPropertyName("url")]
    private string _url { get; set; }

    [JsonPropertyName("height")]
    private int _height { get; set; }

    [JsonPropertyName("width")]
    private int _width { get; set; }
}