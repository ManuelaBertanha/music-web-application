using Microsoft.AspNetCore.Mvc;
using music_web_application.Authorization;

namespace music_web_application.Controller
{
    [ApiController]
    [Route("api/auth")]
    public class SpotifyAuthorizationController : ControllerBase
    {
        private readonly SpotifyAuthService _spotifyAuthService;

        public SpotifyAuthorizationController(SpotifyAuthService spotifyAuthService)
        {
            _spotifyAuthService = spotifyAuthService;
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
            var token = await _spotifyAuthService.GetAccessToken();
            return Ok(new { access_token = token });
        }
    }
}
