namespace Kabutar.Consumer;

public class Topic
{
    public Topic(string name, Server server)
    {
        Name = name;
        Server = server;
    }
    
    public string Name { get; set; }

    public Server Server { get; set; }   
}