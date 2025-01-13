using System.Text.Json.Serialization;

namespace music_web_application.Model.Albums;

public class Item
{
    [JsonPropertyName("artists")]
    private List<Artist> _artists { get; set; }

    [JsonPropertyName("available_markets")]
    private List<string> _availableMarkets { get; set; }

    [JsonPropertyName("disc_number")]
    private int _discNumber { get; set; }

    [JsonPropertyName("duration_ms")]
    private int _durationMs { get; set; }

    [JsonPropertyName("explicit")]
    private bool _explicit { get; set; }

    [JsonPropertyName("external_urls")]
    private ExternalUrl _externalUrl { get; set; }

    [JsonPropertyName("href")]
    private string _href { get; set; }

    [JsonPropertyName("id")]
    private string _id { get; set; }

    [JsonPropertyName("is_playable")]
    private bool _isPlayable { get; set; }

    [JsonPropertyName("linked_from")]
    private LinkedFrom _linkedFrom { get; set; }

    [JsonPropertyName("restrictions")]
    private Restriction _restriction { get; set; }

    [JsonPropertyName("name")]
    private string _name { get; set; }

    [JsonPropertyName("preview_url")]
    private string _previewUrl { get; set; }

    [JsonPropertyName("track_number")]
    private int _trackNumber { get; set; }

    [JsonPropertyName("type")]
    private string _type { get; set; }

    [JsonPropertyName("uri")]
    private string _uri { get; set; }

    [JsonPropertyName("is_local")]
    private bool _isLocal { get; set; }
}