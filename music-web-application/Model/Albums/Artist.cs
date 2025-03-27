using System.Text.Json.Serialization;

namespace music_web_application.Model.Albums;

public class Artist
{
    [JsonPropertyName("external_urls")]
    public ExternalUrl ExternalUrl { get; set; }

    [JsonPropertyName("href")]
    public string Href { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("uri")]
    public string Uri { get; set; }
}