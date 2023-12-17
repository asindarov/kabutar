namespace Kabutar.Consumer;

public class Server
{
    public Server(string serverUri)
    {
        ServerUri = serverUri;
    }
    
    public string ServerUri { get; set; }
}
