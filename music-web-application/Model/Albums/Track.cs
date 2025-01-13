using System.Text.Json.Serialization;

namespace music_web_application.Model.Albums;

public class Track
{
    [JsonPropertyName("href")]
    private string _href { get; set; }

    [JsonPropertyName("limit")]
    private int _limit { get; set; }

    [JsonPropertyName("next")]
    private string _next { get; set; }

    [JsonPropertyName("offset")]
    private int _offset { get; set; }

    [JsonPropertyName("previous")]
    private string _previous { get; set; }

    [JsonPropertyName("total")]
    private int _total { get; set; }

    [JsonPropertyName("items")]
    private List<Item> _items { get; set; }
}