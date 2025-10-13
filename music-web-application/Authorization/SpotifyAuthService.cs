using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.Extensions.Caching.Memory;

namespace music_web_application.Authorization;

public class SpotifyAuthService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    private readonly IMemoryCache _memoryCache;

    private const string TokenCacheKey = "SpotifyAccessToken";

    public SpotifyAuthService(HttpClient httpClient, IConfiguration configuration, IMemoryCache memoryCache)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _memoryCache = memoryCache;
    }
    
    public async Task<string> GetAccessToken()
    {
        if (_memoryCache.TryGetValue(TokenCacheKey, out string cachedToken)) return cachedToken;
        
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

        //var authHeader = $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"))}";
        //requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Basic", authHeader);
        requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
        
        var response = await _httpClient.SendAsync(requestMessage);
        response.EnsureSuccessStatusCode();
        
        var jsonResponse = await response.Content.ReadAsStringAsync();
        var token = JsonSerializer.Deserialize<SpotifyToken>(jsonResponse);

        _memoryCache.Set(TokenCacheKey, token.AccessToken, TimeSpan.FromMinutes(55));

        return token.AccessToken;
    }
}