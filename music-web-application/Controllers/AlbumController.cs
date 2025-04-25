using Microsoft.AspNetCore.Mvc;
using music_web_application.Services;

namespace music_web_application.Controllers;

[ApiController]
[Route("album")]
public class AlbumController : ControllerBase
{
    private readonly AlbumService _albumService;

    public AlbumController(AlbumService albumService)
    {
        _albumService = albumService;
    }
}