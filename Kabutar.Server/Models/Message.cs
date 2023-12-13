using System.Text;
using Kabutar.Server.Dtos;

namespace Kabutar.Server.Models;

public class Message
{
    public int OffSet { get; set; }

    public int TopicId { get; set; }

    public Topic Topic { get; set; }
    
    public string Data { get; set; }

    public bool IsProcessed { get; set; }

    internal Message FromMessageDto(MessageDto messageDto)
    {
        Data = messageDto.Data;
        return this;
    }

    internal Message WithTopic(Topic topic)
    {
        Topic = topic;

        return this;
    }

    internal Message AndWithServer(Server server)
    {
        Topic.Server = server;

        return this;
    }
}
