using System.Text.Json.Serialization;

namespace music_web_application.Model.Albums;

public class Album
{
    [JsonPropertyName("album_type")]
    private string _albumType { get; set; }

    [JsonPropertyName("total_tracks")]
    private int _totalTracks { get; set; }

    [JsonPropertyName("available_markets")]
    private List<string> _availableMarkets { get; set; }

    [JsonPropertyName("external_urls")]
    private ExternalUrl _externalUrl { get; set; }

    [JsonPropertyName("href")]
    private string _href { get; set; }

    [JsonPropertyName("id")]
    private string _id { get; set; }

    [JsonPropertyName("images")]
    private List<Image> _images { get; set; }

    [JsonPropertyName("name")]
    private string _name { get; set; }

    [JsonPropertyName("release_date")]
    private string _releaseDate { get; set; }

    [JsonPropertyName("release_date_precision")]
    private string _releaseDatePrecision { get; set; }

    [JsonPropertyName("restrictions")]
    private Restriction _restriction { get; set; }

    [JsonPropertyName("type")]
    private string _type { get; set; }

    [JsonPropertyName("uri")]
    private string _uri { get; set; }

    [JsonPropertyName("artists")]
    private List<Artist> _artists { get; set; }

    [JsonPropertyName("tracks")]
    private Track _tracks { get; set; }

    [JsonPropertyName("copyrights")]
    private List<Copyright> _copyrights { get; set; }

    [JsonPropertyName("external_ids")]
    private ExternalId _externalId { get; set; }

    [JsonPropertyName("genres")]
    private List<string> _genres { get; set; }

    [JsonPropertyName("label")]
    private string _label { get; set; }

    [JsonPropertyName("popularity")]
    private int _popularity { get; set; }
}