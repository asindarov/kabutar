namespace Kabutar.Server.Models;

public class Server
{
    public int Id { get; set; }

    public string ServerUri { get; set; }
    
    public IList<Topic> Topics { get; set; }
}
