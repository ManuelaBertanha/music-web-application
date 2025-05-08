using music_web_application.Model.Albums;

namespace music_web_application.Services.Interfaces;

public interface IAlbumHandlingService
{
    public Task<Album> FetchAlbumDataById(string id);
}