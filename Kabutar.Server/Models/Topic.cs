namespace Kabutar.Server.Models;

public class Topic
{
    public Topic(string name)
    {
        Name = name;
    }

    public int Id { get; set; }
    
    public string Name { get; set; }

    public IList<Message> Messages { get; set; }
    
    public static Topic Empty => new Topic(string.Empty);
}
