using System.Text.Json.Serialization;

namespace music_web_application.Model.Albums;

public class ExternalId
{
    [JsonPropertyName("isrc")]
    public string Isrc { get; set; }

    [JsonPropertyName("ean")]
    public string Ean { get; set; }

    [JsonPropertyName("upc")]
    public string Upc { get; set; }
}