using Domain.ShareData.Enums;
using System.Text.Json.Serialization;

namespace Domain.ShareData.Base
{


    public class AiModelBase
    {

        public string Id { get; set; }

        [JsonPropertyName("Url")]
        public string Url { get; set; } = "https://api-inference.huggingface.co/models/wasmdashai/";

        [JsonPropertyName("Headers")]
        public AiModelHeader Headers { get; set; } = new AiModelHeader();

        [JsonPropertyName("Method")]
        public string Method { get; set; } = "POST";
        public string ModelID { get; set; } = "";
        public string ModelName { get; set; }
        public string? Key { get; set; }
        public ServiceModelType ServiceType { get; set; }
    }

}
