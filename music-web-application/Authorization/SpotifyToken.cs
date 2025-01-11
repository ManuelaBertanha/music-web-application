using System.Text.Json.Serialization;

namespace music_web_application.Authorization
{
    public class SpotifyToken
    {
        [JsonPropertyName("access_token")]
        private string _accessToken {  get; set; }

        [JsonPropertyName("token_type")]
        private string _tokenType {  get; set; }

        [JsonPropertyName("expires_in")]
        private int _expiresIn { get; set; }
    }
}
