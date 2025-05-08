namespace music_web_application.Model;

public class WebAppException : Exception
{
    public int? StatusCode { get; }
    public string? SpotifyErrorMessage { get; }

    //public WebAppException(string message) : base(message) {}
    
    //public WebAppException(string message, Exception innerException) : base(message, innerException) {}

    public WebAppException(string message, WebAppException innerException) : base(message, innerException)
    {
        StatusCode = innerException.StatusCode;
        SpotifyErrorMessage = innerException.SpotifyErrorMessage;
    }

    public WebAppException(int statusCode, string spotifyErrorMessage)
        : base($"Spotify Web API Error (status code {statusCode}): {spotifyErrorMessage}")
    {
        StatusCode = statusCode;
        SpotifyErrorMessage = spotifyErrorMessage;
    }
    
}