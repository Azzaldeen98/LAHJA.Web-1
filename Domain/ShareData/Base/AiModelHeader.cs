using System.Text.Json.Serialization;

namespace Domain.ShareData.Base
{
    public class AiModelHeader
    {
        [JsonPropertyName("Authorization")]
        public string Authorization { get; set; }

        [JsonPropertyName("Content-Type")]
        public string ContentType { get; set; } = "application/json";
    }

}
