using System.Text.Json.Serialization;

namespace api_WebFront.Data
{
    public class ErrorResponse
    {
        [JsonPropertyName("title")]
        public string? Title { get; set; }
        [JsonPropertyName("status")]
        public string? Status { get; set; }
        [JsonPropertyName("errors")]
        public Dictionary<string, List<String>>? Errors { get; set; }
    }
}
