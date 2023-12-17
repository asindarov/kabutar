using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
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
        // var json = JsonSerializer.Serialize<Message>(_message);
        // using var message = new StringContent(JsonSerializer.Serialize<Message>(_message), Encoding.UTF8, "application/json");
        
        var requestUrl = new Uri($"{URI_CONSTANTS.BASEURL}/{URI_CONSTANTS.TOPICS}/{_message.Topic.Name}/{URI_CONSTANTS.MESSAGES}");
        var response = await _httpClient.PostAsJsonAsync(requestUrl, _message);

        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<DeliveryResult>();
    }
}
