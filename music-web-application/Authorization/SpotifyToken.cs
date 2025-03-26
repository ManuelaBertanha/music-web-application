using System.Text.Json.Serialization;

namespace music_web_application.Authorization;

public class SpotifyToken
{
    [JsonPropertyName("access_token")]
    public string AccessToken {  get; set; }

    [JsonPropertyName("token_type")]
    public string TokenType {  get; set; }

    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; }
}