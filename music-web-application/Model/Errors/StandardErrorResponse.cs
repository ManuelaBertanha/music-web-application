using System.Text.Json.Serialization;

namespace music_web_application.Model.Errors;

public class StandardErrorResponse
{
    [JsonPropertyName("message")]
    public string? Message { get; set; }
    
    [JsonPropertyName("stackTrace")]
    public string? StackTrace { get; set; }
    
    public StandardErrorResponse? InnerError { get; set; }

    public static StandardErrorResponse CreateErrorResponse(Exception ex, IWebHostEnvironment env)
    {
        return new StandardErrorResponse
        {
            Message = ex.Message,
            StackTrace = env.IsDevelopment() ? ex.StackTrace : null,
            InnerError = ex.InnerException != null ? CreateErrorResponse(ex.InnerException, env) : null
        };
    }
}