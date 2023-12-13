using System.Text.Json.Serialization;

namespace Kabutar.Producer;

public class Server
{
    public Server(string serverUri)
    {
        ServerUri = serverUri;
    }
    
    public string ServerUri { get; set; }
    
    // public IList<Topic> Topics { get; set; }
}
