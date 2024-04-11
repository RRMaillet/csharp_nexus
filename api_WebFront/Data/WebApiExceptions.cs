using System.Text.Json;

namespace api_WebFront.Data
{
    public class WebApiExceptions: Exception
    {
        public ErrorResponse? ErrorResponse { get; }

        public WebApiExceptions(string errorJson)
        {
            ErrorResponse = JsonSerializer.Deserialize<ErrorResponse>(errorJson);
        }
    }
}
