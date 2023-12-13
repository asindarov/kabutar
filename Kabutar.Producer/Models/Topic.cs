using System.Text.Json.Serialization;

namespace Kabutar.Producer;

public class Topic
{
    public Topic(string name, string serverUri)
    {
        Name = name;
        Server = new Server(serverUri);
    }

    public string Name { get; set; }

    public Server Server { get; set; }
    
    public static Topic Empty => new Topic(name: string.Empty, serverUri: string.Empty);
}
