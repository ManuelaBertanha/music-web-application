using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace music_web_application.Authorization;

public class SpotifyAuthService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    
    private DateTime _tokenExpiry = DateTime.MinValue;

    public SpotifyAuthService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }
    
    public async Task<string> GetAccessToken()
    {
        var clientId = Environment.GetEnvironmentVariable("SPOTIFY_WEB_API_CLIENT_ID") ?? _configuration["Spotify:ClientId"];
        var clientSecret = Environment.GetEnvironmentVariable("SPOTIFY_WEB_API_CLIENT_SECRET") ?? _configuration["Spotify:ClientSecret"];

        if (string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(clientSecret))
        {
            throw new InvalidOperationException("ClientId or ClientSecret values are missing.");
        }

        var requestBody = new Dictionary<string, string>
        {
            ["grant_type"] = "client_credentials",
            ["client_id"] = clientId,
            ["client_secret"] = clientSecret
        };

        var requestMessage = new HttpRequestMessage(HttpMethod.Post,
            Environment.GetEnvironmentVariable("SPOTIFY_WEB_API_TOKEN_ENDPOINT_URI") ?? _configuration["Spotify:TokenEndpoint"])
        {
            Content = new FormUrlEncodedContent(requestBody)
        };

        requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
        
        var response = await _httpClient.SendAsync(requestMessage);
        response.EnsureSuccessStatusCode();
        
        var jsonResponse = await response.Content.ReadAsStringAsync();
        var token = JsonSerializer.Deserialize<SpotifyToken>(jsonResponse);

        return token.AccessToken;
    }
}