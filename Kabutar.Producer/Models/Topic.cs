namespace Kabutar.Producer;

public class Topic
{
    public Topic(string name, string serverUri)
    {
        Name = name;
        ServerUri = serverUri;
    }

    public string Name { get; set; }

    public string ServerUri { get; set; }
    
    public static Topic Empty => new Topic(name: string.Empty, string.Empty);
}
