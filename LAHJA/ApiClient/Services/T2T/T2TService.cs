using LAHJA.ApiClient.Models;
using LAHJA.ApiClient.Repository;
using LAHJA.Data.UI.Models;
using System.Text;
using System.Text.Json;
using Microsoft.JSInterop;
 using Shared.Wrapper;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace LAHJA.ApiClient.Services
{
    public interface IT2TService
    {
        Task<Result<ServiceAIResponse>> T2TAsync(QueryRequestTextToText model);
    
        Task<Result<ServiceAIResponse>> T2TClientJSAsync(QueryRequestTextToText model);
    }
    public class T2TService: IT2TService
    {

        private readonly IJSRuntime _JSRuntime;

        private IT2TRepository _t2TRepository;

        public T2TService(IT2TRepository t2TRepository, IJSRuntime jSRuntime)
        {
            _t2TRepository = t2TRepository;
            _JSRuntime = jSRuntime;
        }

        public async Task<Result<ServiceAIResponse>> T2TAsync(QueryRequestTextToText data)
        {
            //var res= await _t2TRepository.T2TAsync(model);
            //return res;

            // var data = JsonSerializer.Deserialize<T2TRequest>(jsonData);
            if (data == null)
                throw new ArgumentException("Invalid JSON data");

            try
            {
                // Step 1: POST request to get EVENT_ID
                using var httpClient = new HttpClient();
                var postContent = new StringContent(JsonSerializer.Serialize(new { data = new object[] { data.Text, data.Key } }), Encoding.UTF8, "application/json");

                var postResponse = await httpClient.PostAsync(data.URL, postContent);
                postResponse.EnsureSuccessStatusCode();

                var postResponseContent = await postResponse.Content.ReadAsStringAsync();
                var postData = JsonSerializer.Deserialize<PostResponseBase>(postResponseContent);
                var eventId = postData?.event_id;

                if (string.IsNullOrEmpty(eventId))
                    throw new Exception("Event ID not found in response");

                // Step 2: GET request to stream data
                var getResponse = await httpClient.GetAsync($"{data.URL}/{eventId}", HttpCompletionOption.ResponseHeadersRead);
                getResponse.EnsureSuccessStatusCode();

                using var stream = await getResponse.Content.ReadAsStreamAsync();
                using var reader = new StreamReader(stream, Encoding.UTF8);
                var result = new StringBuilder();

                while (!reader.EndOfStream)
                {
                    var line = await reader.ReadLineAsync();
                    if (line != null)
                        result.AppendLine(line);
                }

                // Parse the result to find the desired JSON line
                var resultString = result.ToString();
                var dataLine = resultString.Split('\n', StringSplitOptions.RemoveEmptyEntries)
                                           .FirstOrDefault(line => line.StartsWith("data:"));

                if (dataLine == null)
                    throw new Exception("No data line found in the response");

                var jsonString = dataLine.Replace("data: ", "").Trim();

                if (jsonString != null)
                {
                    string[] decodedArray = JsonSerializer.Deserialize<string[]>(jsonString);

                    if (decodedArray != null && decodedArray.Count() > 0)
                    {
                        var resText = decodedArray[0];

                        return Result<ServiceAIResponse>.Success(new ServiceAIResponse { Result= resText });
                    }
                }

                return  Result<ServiceAIResponse>.Fail("null Response !!");


            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log errors)
                Console.WriteLine($"Error: {ex.Message}");
                return  Result<ServiceAIResponse>.Fail(ex.Message);
            }

        }

        public async Task<Result<ServiceAIResponse>> T2TClientJSAsync(QueryRequestTextToText model)
        {
            try
            {
                string json = JsonSerializer.Serialize(model);
                var response = await _JSRuntime.InvokeAsync<string>("t2t", json);
                if (response != null)
                {
                    string[] decodedArray = JsonSerializer.Deserialize<string[]>(response);
                    string decodedText = decodedArray[0];
                    if (!string.IsNullOrEmpty(decodedText))
                        return Result<ServiceAIResponse>.Success(new ServiceAIResponse { Result = decodedText });
                }

                return Result<ServiceAIResponse>.Fail();
            }
            catch (Exception ex)
            {
                return Result<ServiceAIResponse>.Fail(ex.Message);
            }
    
        }
    }
}
