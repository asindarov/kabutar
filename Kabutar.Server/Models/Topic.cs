namespace Kabutar.Server.Models;

public class Topic
{
    public Topic(string name, int serverId)
    {
        Name = name;
        ServerId = serverId;
    }

    public int Id { get; set; }
    
    public string Name { get; set; }

    public IList<Message> Messages { get; set; }
    
    public int ServerId { get; set; } 
    
    public Server Server { get; set; }

    public static Topic Empty => new Topic(string.Empty, int.MinValue);
}
