namespace Kabutar.Producer;

public class Message
{
    public Message() : this(Topic.Empty, string.Empty)
    { }
    
    public Message(Topic topic, string data)
    {
        Topic = topic;
        Data = data;
    }
    
    public Topic Topic { get; set; }
    
    public string Data { get; set; }
}
