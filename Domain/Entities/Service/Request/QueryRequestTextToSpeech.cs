using Domain.ShareData.Base;
using Domain.ShareData.Enums;
using System.Text.Json.Serialization;

namespace Domain.Entities.Service.Request
{
    public class QueryRequestTextToSpeech : AiModelBase
    {

        [JsonPropertyName("TagId")]
        public string TagId { get; set; } = "LAHJAAudioPlayerId";

        public GenderType TypeSound { get; set; }
        public LahjaTypeModel LahjaType { get; set; }
    }

}
