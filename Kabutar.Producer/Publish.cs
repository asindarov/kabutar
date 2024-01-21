using System.Net.Http.Json;
using Kabutar.Producer.Constants;

namespace Kabutar.Producer;

public class Publish
{
    public Publish(Message message)
    {
        _message = message;
    }

    private Message _message;
    private HttpClient _httpClient;

    public Publish WithHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        
        return this;
    }
    
    public async Task<DeliveryResult?> StartAsync()
    {
        var requestUrl = new Uri($"{_message.Topic.ServerUri}/{URI_CONSTANTS.TOPICS}/{_message.Topic.Name}/{URI_CONSTANTS.MESSAGES}");
        var response = await _httpClient.PostAsJsonAsync(requestUrl, _message);

        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<DeliveryResult>();
    }
}
