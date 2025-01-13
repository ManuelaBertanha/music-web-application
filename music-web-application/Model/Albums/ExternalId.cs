using System.Text.Json.Serialization;

namespace music_web_application.Model.Albums;

public class ExternalId
{
    [JsonPropertyName("isrc")]
    private string _isrc { get; set; }

    [JsonPropertyName("ean")]
    private string _ean { get; set; }

    [JsonPropertyName("upc")]
    private string _upc { get; set; }
}