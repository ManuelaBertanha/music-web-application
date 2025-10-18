using Microsoft.AspNetCore.Mvc;
using music_web_application.Authorization;
using music_web_application.Model;
using music_web_application.Model.Errors;

namespace music_web_application.Controllers;

[ApiController]
[Route("api/auth")]
public class SpotifyAuthorizationController : ControllerBase
{
    private readonly SpotifyAuthService _spotifyAuthService;
    private readonly IWebHostEnvironment _env;

    public SpotifyAuthorizationController(SpotifyAuthService spotifyAuthService, IWebHostEnvironment env)
    {
        _spotifyAuthService = spotifyAuthService;
        _env = env;
    }
        
    /// <summary>Returns the access token.</summary>
    /// <remarks>Returns the access token for a given Spotify account, allowing other Spotify API endpoints to be used.</remarks>
    /// <response code="200">Access token obtained successfully.</response>
    /// <response code="400">Malformed request because some parameter was passed incorrectly.</response>
    /// <response code="401">Missing or invalid credentials in Header.</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpGet("getAccessToken")]
    public async Task<IActionResult> GetAccessToken()
    {
        try
        {
            var token = await _spotifyAuthService.GetAccessToken();
            return Ok(new { access_token = token });
        }
        catch (WebAppException ex)
        {
            return StatusCode(ex.StatusCode ?? 500, StandardErrorResponse.CreateErrorResponse(ex, _env));
        }
        catch (Exception ex)
        {
            return StatusCode(500, StandardErrorResponse.CreateErrorResponse(ex, _env));
        }
        
    }
}
