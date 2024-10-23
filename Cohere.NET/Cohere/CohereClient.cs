using Cohere.Models;
using Polly;
using Polly.Extensions.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Cohere;

public class CohereClient
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private readonly int _retryCount = 3;
    private readonly JsonSerializerOptions _jsonSerializerOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
    };

    // <summary>
    // Initalizes a new instance of the CohereClient class
    // </summary>
    // <param name="apiKey"> The API key to use for requests </param>
    public CohereClient(string apiKey)
    {
        _apiKey = apiKey;
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://api.cohere.ai")
        };
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);

    }

    // <summary>
    // Sends a request to the Cohere API to generate text based on messages provided
    // </summary>
    // <param name="chatRequest"> The request body sent to Cohere to generate text </param>
    // <returns> The response from Cohere as a ChatResponse object </returns>
    public async Task<ChatResponse> ChatAsync(ChatRequest chatRequest)
    {
        var response = await SendRequestAsync("chat", chatRequest);

        return (ChatResponse) response;
    }

    // <summary>
    // Sends a request to the Cohere API to classify text
    // </summary>
    // <param name="classifyRequest"> The request body sent to Cohere to classify </param>
    // <returns> The response from Cohere as a ClassifyResponse object </returns>
    public async Task<ClassifyResponse> ClassifyAsync(ClassifyRequest classifyRequest)
    {
        var response = await SendRequestAsync("classify", classifyRequest);

        return (ClassifyResponse) response;
    }

    // <summary>
    // Sends a request to the Cohere API to rerank text
    // </summary>
    // <param name="rerankRequest"> The request body sent to Cohere to rerank </param>
    // <returns> The response from Cohere as a RerankResponse object </returns>
    public async Task<RerankResponse> RerankAsync(RerankRequest rerankRequest)
    {
        var response = await SendRequestAsync("rerank", rerankRequest);

        return (RerankResponse) response;
    }

    // <summary>
    // Private method to send a request to the Cohere API
    // </summary>
    // <param name="endpoint"> The endpoint to send the request to </param>
    // <param name="requestBody"> The request body to send to the API </param>
    // <returns> The response from the API as an ICohereResponse object </returns> 
    private async Task<ICohereResponse> SendRequestAsync(string endpoint, ICohereRequest requestBody)
    {
        var response = await GetRetryPolicy().ExecuteAsync(async () => {
            var request = new HttpRequestMessage(HttpMethod.Post, $"/v2/{endpoint}")
            {
                Content = new StringContent(JsonSerializer.Serialize(requestBody, _jsonSerializerOptions), Encoding.UTF8, "application/json")
            };

            return await _httpClient.SendAsync(request);
        });

        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine($"Failed to retrieve results from Cohere. Status code: {response.StatusCode}");
            throw new HttpRequestException($"Cohere API call failed with status code: {response.StatusCode}");
        }

        var responseContent = await response.Content.ReadAsStringAsync();

        ICohereResponse result = endpoint switch
        {
            "chat" => DeserializeResponse<ChatResponse>(responseContent),
            "classify" => DeserializeResponse<ClassifyResponse>(responseContent),
            "rerank" => DeserializeResponse<RerankResponse>(responseContent),
            _ => throw new InvalidOperationException("Invalid endpoint provided.")
        };

        return result;
    }

    // <summary>
    // Private generic method to deserialize the response from the Cohere API
    // </summary>
    // <param name="responseContent"> The content of the response from the API </param>
    // <returns> The deserialized response as a generic type </returns>
    private T DeserializeResponse<T>(string responseContent) where T : ICohereResponse
    {
        return JsonSerializer.Deserialize<T>(responseContent, _jsonSerializerOptions)
            ?? throw new InvalidOperationException("Failed to deserialize the response from Cohere.");
    }

    // <summary>
    // Private method to get the retry policy for the HttpClient
    // </summary>
    // <returns> The retry policy for the HttpClient </returns>
    private AsyncPolicy<HttpResponseMessage> GetRetryPolicy()
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .OrResult(msg =>
                msg.StatusCode is System.Net.HttpStatusCode.NotFound)
            .WaitAndRetryAsync(_retryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
    }
}