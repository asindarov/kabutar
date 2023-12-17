using System.Text;
using Kabutar.Server.Features.Messages.Dto;
using Kabutar.Server.Features.Messages.Requests.PublishMessage;

namespace Kabutar.Server.Models;

public class Message
{
    public int OffSet { get; set; }

    public int TopicId { get; set; }

    public Topic Topic { get; set; }
    
    public string Data { get; set; }

    public bool IsProcessed { get; set; }

    internal Message FromPublishMessageRequest(PublishMessageRequest request)
    {
        Data = request.Data;
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
