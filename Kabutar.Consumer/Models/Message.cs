namespace Kabutar.Consumer;

public class Message
{
    public Topic Topic { get; set; }
    
    public string Data { get; set; }

    public int OffSet { get; set; }

    public bool IsProcessed { get; set; }
}
