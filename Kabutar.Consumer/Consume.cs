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
                $"{URI_CONSTANTS.BASEURL}/{URI_CONSTANTS.TOPICS}/{_topic.Name}?{URI_CONSTANTS.SERVERURI}={_topic.Server.ServerUri}")
                .Uri;

        var messages = await _httpClient.GetFromJsonAsync<DeliveryResult>(requestUri);

        return messages;
    }
}
