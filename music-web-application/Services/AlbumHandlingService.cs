using System.Net.Http.Headers;
using System.Text.Json;
using music_web_application.Model;
using music_web_application.Model.Albums;
using music_web_application.Model.Errors;
using music_web_application.Services.Interfaces;

namespace music_web_application.Services;

public class AlbumHandlingService : IAlbumHandlingService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public AlbumHandlingService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }
    
    public async Task<Album> FetchAlbumDataById(string id)
    {
        var albumData = new Album();

        try
        {
            var requestUri =
                $"{Environment.GetEnvironmentVariable("SPOTIFY_WEB_API_BASE_URI")}" +
                $"{Environment.GetEnvironmentVariable("SPOTIFY_WEB_API_ALBUMS_ENDPOINT")}/{id}";

            var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "token");

            var response = await _httpClient.SendAsync(request);
            var jsonResponse = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var errorResponse = JsonSerializer.Deserialize<SpotifyErrorResponse>(jsonResponse);
                if (errorResponse != null) throw new 
                    WebAppException(errorResponse.SpotifyError.Status, errorResponse.SpotifyError.Message);
            }

            albumData = JsonSerializer.Deserialize<Album>(jsonResponse);
            return albumData;
        }
        catch (WebAppException ex)
        {
            throw new WebAppException(message: "Spotify Web API returned an error.", ex);
        }
    }
}