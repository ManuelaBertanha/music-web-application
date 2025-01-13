using System.Text.Json.Serialization;

namespace music_web_application.Model.Albums;

public class Artist
{
    [JsonPropertyName("external_urls")]
    private ExternalUrl _externalUrl { get; set; }

    [JsonPropertyName("href")]
    private string _href { get; set; }

    [JsonPropertyName("id")]
    private string _id { get; set; }

    [JsonPropertyName("name")]
    private string _name { get; set; }

    [JsonPropertyName("type")]
    private string _type { get; set; }

    [JsonPropertyName("uri")]
    private string _uri { get; set; }
}