using System.Net.Http.Headers;
using System.Text.Json;
using music_web_application.Authorization;
using music_web_application.Model;
using music_web_application.Model.Albums;
using music_web_application.Model.Errors;
using music_web_application.Services.Interfaces;

namespace music_web_application.Services;

public class AlbumHandlingService : IAlbumHandlingService
{
    private readonly HttpClient _httpClient;
    //private readonly IConfiguration _configuration;
    private readonly SpotifyAuthService _spotifyAuthService;

    public AlbumHandlingService(HttpClient httpClient, IConfiguration configuration, SpotifyAuthService spotifyAuthService)
    {
        _httpClient = httpClient;
        //_configuration = configuration;
        _spotifyAuthService = spotifyAuthService;
    }
    
    public async Task<Album> FetchAlbumDataById(string id)
    {
        var accessToken = await _spotifyAuthService.GetAccessToken();

        try
        {
            var requestUri =
                $"{Environment.GetEnvironmentVariable("SPOTIFY_WEB_API_BASE_URI")}" +
                $"{Environment.GetEnvironmentVariable("SPOTIFY_WEB_API_ALBUMS_ENDPOINT")}/{id}";

            var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _httpClient.SendAsync(request);
            var jsonResponse = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var errorResponse = JsonSerializer.Deserialize<SpotifyErrorResponse>(jsonResponse);
                if (errorResponse != null) throw new 
                    WebAppException(errorResponse.SpotifyError.Status, errorResponse.SpotifyError.Message);
            }

            return JsonSerializer.Deserialize<Album>(jsonResponse);
        }
        catch (WebAppException ex)
        {
            throw new WebAppException(message: "Spotify Web API returned an error.", ex);
        }
    }
}