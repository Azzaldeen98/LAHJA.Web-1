using System.Text.Json.Serialization;
using LAHJA.Config;
namespace LAHJA.Data.UI.Models
{
    public class QueryRequestTextToSpeechHeader
    {
        [JsonPropertyName("Authorization")]
        public string Authorization { get; set; } 

        [JsonPropertyName("Content-Type")]
        public string ContentType { get; set; } = "application/json";
    }
    public class QueryRequestTextToSpeech
    {
        [JsonPropertyName("Url")]
        //public string Url { get; set; } = "https://api-inference.huggingface.co/models/wasmdashai/vits-ar-sa-huba-v2";
        public string Url { get; set; } = "https://api-inference.huggingface.co/models/wasmdashai/";

        [JsonPropertyName("Headers")]
        public QueryRequestTextToSpeechHeader Headers { get; set; } = new QueryRequestTextToSpeechHeader();

        [JsonPropertyName("Method")]
        public string Method { get; set; } = "POST";
        public string ModelAi { get; set; } = "vits-ar-sa-huba-v2";

        [JsonPropertyName("Data")]
        public string Data { get; set; } 

        [JsonPropertyName("TagId")]
        public string TagId { get; set; } = "LAHJAAudioPlayerId";
    }  
    
    public class QueryRequestTextToText
    {
        [JsonPropertyName("URL")]
        public string URL { get; set; } = "https://wasmdashai-t2t.hf.space/gradio_api/call/predict";



        [JsonPropertyName("Method")]
        public string Method { get; set; } = "POST";

        [JsonPropertyName("Text")]
        public string Text { get; set; } = "السلام عليكم ورحمة الله";

        [JsonPropertyName("Key")]
        public string Key { get; set; } 
    }


 

public class DataModelText2Text
    {
        /// <summary>
        /// Represents the space to which the client will connect.
        /// </summary>
        [JsonPropertyName("Space")]
        public string Space { get; set; } = "wasmdashai/T2T";

        /// <summary>
        /// Represents the function to be invoked on the client.
        /// </summary>
        [JsonPropertyName("Function")]
        public string Function { get; set; } = "/predict";

        /// <summary>
        /// Represents the input text for the function.
        /// </summary>
        [JsonPropertyName("Input")]
        public string Input { get; set; } = "";

        /// <summary>
        /// Represents the key used for authentication or additional information.
        /// </summary>
        [JsonPropertyName("Key")]
        public string Key { get; set; } = "AIzaSyC85_3TKmiXtOpwybhSFThZdF1nGKlxU5c";

        /// <summary>
        /// Represents the key used for authentication or additional information.
        /// </summary>
        [JsonPropertyName("Token")]
        public string Token { get; set; } = "";
    }

    public class DataModelText2Speech
    {
        /// <summary>
        /// Represents the space to which the client will connect.
        /// </summary>
        [JsonPropertyName("Space")]
        public string Space { get; set; } = "wasmdashai/RunTasking";

        /// <summary>
        /// Represents the function to be invoked on the client.
        /// </summary>
        [JsonPropertyName("Function")]
        public string Function { get; set; } = "/predict";

        /// <summary>
        /// Represents the input text for the function.
        /// </summary>
        [JsonPropertyName("Input")]
        public string Input { get; set; } = "";

        /// <summary>
        /// Represents the key used for authentication or additional information.
        /// </summary>
        [JsonPropertyName("Model")]
        public string Model { get; set; } = "wasmdashai/vits-ar-sa-huba-v2";


        /// <summary>
        /// Represents the key used for authentication or additional information.
        /// </summary>
        [JsonPropertyName("Token")]
        public string Token { get; set; } = "";

        /// <summary>
        /// Represents the speech rate.
        /// </summary>
        [JsonPropertyName("SR")]
        public double SR { get; set; } = 0.8;

        /// <summary>
        /// Represents the audio player ID.
        /// </summary>
        [JsonPropertyName("AudioPlayerID")]
        public string AudioPlayerID { get; set; } = "";
    }

    public class DataModelVoiceBot {

        [JsonPropertyName("Speech")]
        public DataModelText2Speech Speech { get; set; }

        [JsonPropertyName("Text2Text")]
        public DataModelText2Text Text2Text { get; set; }
    }


}
