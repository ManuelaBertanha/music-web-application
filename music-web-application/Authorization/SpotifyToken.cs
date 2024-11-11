using System.Text.Json.Serialization;

namespace music_web_application.Authorization
{
    public class AccessToken
    {
        [JsonPropertyName("access_token")]
        private string Access_Token {  get; set; }

        [JsonPropertyName("token_type")]
        private string Token_Type {  get; set; }

        [JsonPropertyName("expires_in")]
        private int Expires_In { get; set; }
    }
}
