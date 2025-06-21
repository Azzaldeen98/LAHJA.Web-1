using LAHJA.Data.UI.Models;

namespace LAHJA.ApiClient.Models
{
    public class QueryRequest
    {
        public QueryRequestTextToText QueryRequestTextToText { get; set; }
        public QueryRequestTextToSpeech QueryRequestTextToSpeech { get; set; }
    }
}
