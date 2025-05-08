using Microsoft.AspNetCore.Mvc;
using music_web_application.Model;
using music_web_application.Model.Albums;
using music_web_application.Model.Errors;
using music_web_application.Services.Interfaces;

namespace music_web_application.Controllers;

[ApiController]
[Route("albums")]
public class AlbumsController : ControllerBase
{
    private readonly IAlbumHandlingService _albumHandlingService;
    private readonly IWebHostEnvironment _env;

    public AlbumsController(IAlbumHandlingService albumHandlingService, IWebHostEnvironment env)
    {
        _albumHandlingService = albumHandlingService;
        _env = env;
    }
    
    /// <summary>Returns information for a single album.</summary>
    /// <remarks>Returns Spotify catalog information for a single album identified by albumId.</remarks>
    /// <response code="200">Album data obtained successfully.</response>
    /// <response code="400">Bad Request.</response>
    /// <response code="401">Access token revoked by user or expired.</response>
    /// <response code="403">Bad OAuth request.</response>
    /// <response code="429">The app has exceeded its rate limits.</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpGet("getAlbum/{albumId}")]
    public async Task<IActionResult> GetAlbumById([FromRoute] string albumId)
    {
        try
        {
            var albumData = await _albumHandlingService.FetchAlbumDataById(albumId);
            return Ok(new StandardResponse<Album>(albumData));
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