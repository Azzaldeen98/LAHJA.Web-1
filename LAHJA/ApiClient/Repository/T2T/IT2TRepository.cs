using AutoMapper;
using Blazorise.Extensions;
 using Shared.Wrapper;
using LAHJA.ApiClient.Models;
using LAHJA.Data.UI.Models;
using System.Text;
using System.Text.Json;


namespace LAHJA.ApiClient.Repository
{

    public interface IT2TRepository
    {
        Task<Result<string>> T2TAsync(QueryRequestTextToText inputData);
    }

   
    public class T2TRepository : IT2TRepository
    {
  

        private readonly IMapper _mapper;


        public T2TRepository(IMapper mapper)
        {

         
            _mapper = mapper;
           
        }



        public async Task<Result<string>> T2TAsync(QueryRequestTextToText data)
        {
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

                if(jsonString != null)
                {
                    string[] decodedArray = JsonSerializer.Deserialize<string[]>(jsonString);

                    if (decodedArray != null && decodedArray.Count() > 0)
                    {
                        var resText = decodedArray[0];

                        return Result<string>.Success(resText);
                    }
                }
              
                 return Result<string>.Fail("null Response !!");
                
              
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log errors)
                Console.WriteLine($"Error: {ex.Message}");
                return Result<string>.Fail(ex.Message);
            }
        }



    }
}
