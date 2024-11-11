using System.Text.Json.Serialization;

namespace music_web_application.Authorization
{
    public class SpotifyToken
    {
        [JsonPropertyName("access_token")]
        private string AccessToken {  get; set; }

        [JsonPropertyName("token_type")]
        private string TokenType {  get; set; }

        [JsonPropertyName("expires_in")]
        private int ExpiresIn { get; set; }
    }
}
