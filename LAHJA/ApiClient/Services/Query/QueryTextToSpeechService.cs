using ApexCharts;
using Blazorise;
using Blazorise.Extensions;
 using Shared.Wrapper;
using LAHJA.ApiClient.Models;
using LAHJA.Data.UI.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;
using static System.Net.WebRequestMethods;


namespace LAHJA.ApiClient.Services.Query
{

    public interface IQueryTextToSpeechService
    {
         Task<Result<ServiceAIResponse>> TextToSpeechAsync(QueryRequestTextToSpeech requestData);
    }
    public class QueryTextToSpeechService: IQueryTextToSpeechService
    {


        private readonly IJSRuntime _JSRuntime;

        public QueryTextToSpeechService(IJSRuntime jSRuntime)
        {
            _JSRuntime = jSRuntime;
        }


        static async Task<string> TextToSpeechHttpAsync(QueryRequestTextToSpeech body)
        {
          
            if (string.IsNullOrEmpty(body.Data))
            {
                Console.WriteLine("Please enter some text");
                throw new NullReferenceException("Null");
            }

            var payload = new
            {
                data = new object[]
                {
                    body.Data, // The text to convert to speech vits-ar-sa-huba-v2
                    $"wasmdashai/{body.ModelAi}", // Model identifier
                    0.9 // Speaker ID or variation
                }
            };

            var headers = new
            {
                Content_Type = "application/json"
            };

            using (var client = new HttpClient())
            {
                try
                {
                    // Step 1: Send the POST request
                    var response = await client.PostAsync(
                        "https://wasmdashai-runtasking.hf.space/call/predict",
                        new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json")
                    );

                    response.EnsureSuccessStatusCode();
                    var responseBody = await response.Content.ReadAsStringAsync();

                    // Assuming the response contains a field 'event_id'
                    dynamic responseData = JsonConvert.DeserializeObject(responseBody);
                    string eventId = responseData.event_id;

                    Console.WriteLine("Event ID: " + eventId);

                    // Step 2: Use the EVENT_ID in the next request to fetch the audio file
                    var audioResponse = await client.GetAsync($"https://wasmdashai-runtasking.hf.space/call/predict/{eventId}");

                    if (!audioResponse.IsSuccessStatusCode)
                    {
                        throw new Exception("Failed to fetch audio data");
                    }

                    var audioData = await audioResponse.Content.ReadAsStringAsync();

                    // Simulate extracting the audio URL from the response data (modify according to actual response format)
                    var extractedData = ExtractData2(audioData);

                    return "https://wasmdashai-runtasking.hf.space/file="+extractedData.audioPath;
                    //return Result<dynamic>.Success(extractedData);

                    //Console.WriteLine("Audio URL: " + extractedData.audioUrl);

                    //// Use the extracted audio URL to play the audio (this part assumes further processing)
                    //// Here, you would handle the audio playback (e.g., using a player library for C#)
                    //// For now, just output the URL
                    //Console.WriteLine("Audio will be played from URL: " + extractedData.audioPath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    throw new Exception(ex.Message);
                    //return Result<dynamic>.Fail(ex.Message);
                }
            }
        }
      static  dynamic ExtractData2(string blob)
        {
            Console.WriteLine("Blob data before cleaning: " + blob);  // طباعة المحتوى للتحقق منه

            try
            {
                // تقسيم البيانات بناءً على "data: "
                var parts = blob.Split(new[] { "data: " }, StringSplitOptions.None);

                if (parts.Length > 1)
                {
                    // تحليل الجزء الثاني الذي يحتوي على JSON
                    var jsonData = JsonConvert.DeserializeObject<dynamic>(parts[1].Trim());

                    // استخراج البيانات المطلوبة
                    var audioUrl = jsonData[0].url;
                    var audioPath = jsonData[0].path;
                    var originalName = jsonData[0].orig_name;

                    Console.WriteLine($"Audio URL: {audioUrl}");
                    Console.WriteLine($"Audio Path: {audioPath}");
                    Console.WriteLine($"Original Name: {originalName}");

                    // إرجاع البيانات المطلوبة
                    return new { audioUrl = audioUrl, audioPath = audioPath, originalName = originalName };
                }
                else
                {
                    throw new Exception("Data format incorrect.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }
        static  dynamic ExtractData(string blob)
        {
            // You would need to implement actual extraction based on the response structure
            // For example, assuming it's JSON with audioPath and audioUrl properties
            //return System.Text.Json.JsonSerializer.Deserialize<dynamic>(blob);

            try
            {
                // تحويل البيانات إلى كائن ديناميكي
                // تنظيف البيانات لإزالة الجزء غير JSON
                var jsonStart = blob.IndexOf("[");  // البحث عن بداية JSON (المصفوفة)
                var jsonEnd = blob.LastIndexOf("]"); // البحث عن نهاية JSON (المصفوفة)

                if (jsonStart == -1 || jsonEnd == -1)
                {
                    Console.WriteLine("Invalid JSON format in the response.");
                    return null;
                }

                // استخراج النص الذي يمثل JSON
                var jsonString = blob.Substring(jsonStart, jsonEnd - jsonStart + 1);

                // طباعة النص الذي تم تنظيفه للتحقق منه
                Console.WriteLine("Cleaned JSON string: " + jsonString);

                // تحويل البيانات إلى كائن ديناميكي
                var response = JsonConvert.DeserializeObject<dynamic>(jsonString);

                // استخراج البيانات من المصفوفة
                var audioData = response[0];  // نأخذ أول عنصر من المصفوفة
                string audioUrl = audioData.url;   // نأخذ الرابط من الكائن

                Console.WriteLine("Extracted audio URL: " + audioUrl);

                // إرجاع الرابط أو أي بيانات أخرى تحتاجها
                return new { audioUrl = audioUrl, audioPath = audioData.path };
            }
            catch (JsonReaderException ex)
            {
                Console.WriteLine("Error parsing JSON: " + ex.Message);
                throw new JsonReaderException();
            }

        }
        public async Task<Result<ServiceAIResponse>> TextToSpeechAsync2(QueryRequestTextToSpeech requestData)
        {
            try
            {
                //var requestData = new QueryRequestTextToSpeech { Data = inputText, TagId = "OutputPlayerId" };
                string json = System.Text.Json.JsonSerializer.Serialize(requestData);
                if (!string.IsNullOrEmpty(json))
                {
                    //await _JSRuntime.InvokeVoidAsync("queryModelTextToSpeech", "Hiiiiiiiii");
                    var response = await _JSRuntime.InvokeAsync<string>("queryModelTextToSpeech",json);
                    if (response != null)
                    {
                        if (response == "222")
                            return Result<ServiceAIResponse>.Success(new ServiceAIResponse { Result = response });
                        else
                            return Result<ServiceAIResponse>.Fail("333");
                    }
             

                }

                return Result<ServiceAIResponse>.Fail("Error !!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return Result<ServiceAIResponse>.Fail("333");
            }

        }     
        
        public async Task<Result<ServiceAIResponse>> TextToSpeechAsync(QueryRequestTextToSpeech requestData)
        {
            try
            {
                var res = await TextToSpeechHttpAsync(requestData);
                if (!string.IsNullOrEmpty(res))
                {

                    //res = "" + res;
                   
                

                   //await _JSRuntime.InvokeVoidAsync("playerAudio", res);
                   await _JSRuntime.InvokeVoidAsync("playerAudioSource", res, requestData.TagId);
                    //if (response != null)
                    //{
                    //    if (response == "222")
                    return Result<ServiceAIResponse>.Success(new ServiceAIResponse { Result = res });
                    //        else
                    //            return Result<ServiceAIResponse>.Fail("333");
                    //    }
                }
                //var requestData = new QueryRequestTextToSpeech { Data = inputText, TagId = "OutputPlayerId" };
                //string json = JsonSerializer.Serialize(requestData);
                //if (!string.IsNullOrEmpty(json))
                //{
                //    //await _JSRuntime.InvokeVoidAsync("queryModelTextToSpeech", "Hiiiiiiiii");
                //    var response = await _JSRuntime.InvokeAsync<string>("convertTextToSpeech");
                //    if (response != null)
                //    {
                //        if (response == "222")
                //            return Result<ServiceAIResponse>.Success(new ServiceAIResponse { Result = response });
                //        else
                //            return Result<ServiceAIResponse>.Fail("333");
                //    }
                //return Result<ServiceAIResponse>.Success(new ServiceAIResponse { Result = "222" });

                //}

                return Result<ServiceAIResponse>.Fail("333");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return Result<ServiceAIResponse>.Fail("333");
            }

        }



    }
}
