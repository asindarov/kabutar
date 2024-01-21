using System.Net.Http.Json;
using Kabutar.Consumer.Constants;

namespace Kabutar.Consumer;

public class Consume
{
    private Topic _topic;
    private HttpClient _httpClient;

    public Consume(Topic topic)
    {
        _topic = topic;
    }
    
    public Consume WithHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        
        return this;
    }

    public async Task<DeliveryResult> StartAsync()
    {
        var requestUri = 
            new UriBuilder(
                $"{_topic.ServerUri}/{URI_CONSTANTS.TOPICS}/{_topic.Name}")
                .Uri;

        var messages = await _httpClient.GetFromJsonAsync<DeliveryResult>(requestUri);

        return messages;
    }
}
