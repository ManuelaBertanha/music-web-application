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
        
        [HttpGet("getAccessToken")]
        public async Task<IActionResult> GetAccessToken()
        {
            var token = await _spotifyAuthService.GetAccessToken();
            return Ok(new { access_token = token });
        }
    }
}
