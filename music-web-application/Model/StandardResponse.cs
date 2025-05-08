using System.Text.Json.Serialization;

namespace music_web_application.Model;

public class StandardResponse<T>
{
    [JsonPropertyName("data")]
    public T? DataResponse { get; set; }
    
    public StandardResponse(T dataResponse)
    {
        DataResponse = dataResponse;
    }
}