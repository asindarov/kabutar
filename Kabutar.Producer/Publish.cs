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
    
    public async Task<HttpResponseMessage> SendAsync()
    {
        var json = JsonSerializer.Serialize<Message>(_message);
        using var message = new StringContent(JsonSerializer.Serialize<Message>(_message), Encoding.UTF8, "application/json");
        
        var requestUrl = $"{URI_CONSTANTS.BASEURL}/{URI_CONSTANTS.TOPICS}/{_message.Topic.Name}";
        var response = await _httpClient.PostAsync(requestUrl, message);

        response.EnsureSuccessStatusCode();

        
        
        return response;
    }
}
