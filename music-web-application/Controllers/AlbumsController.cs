using Microsoft.AspNetCore.Mvc;
using music_web_application.Services;

namespace music_web_application.Controllers;

[ApiController]
[Route("albums")]
public class AlbumsController : ControllerBase
{
    private readonly AlbumHandlingService _albumHandlingService;

    public AlbumsController(AlbumHandlingService albumHandlingService)
    {
        _albumHandlingService = albumHandlingService;
    }
    
    /// <summary>Returns information for a single album.</summary>
    /// <remarks>Returns Spotify catalog information for a single album identified by albumId.</remarks>
    /// <response code="200">Album data obtained successfully.</response>
    /// <response code="401">Access token revoked by user or expired.</response>
    /// <response code="403">Bad OAuth request.</response>
    /// <response code="429">The app has exceeded its rate limits.</response>
    [HttpGet("getAlbum/{albumId}")]
    public IActionResult GetAlbumById([FromRoute] string albumId)
    {
        return Ok();
    }
}