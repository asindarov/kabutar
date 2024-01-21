namespace Kabutar.Consumer;

public class Topic
{
    public Topic(string name, string serverUri)
    {
        Name = name;
        ServerUri = serverUri;
    }
    
    public string Name { get; set; }

    public string ServerUri { get; set; }   
}