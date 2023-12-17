using Kabutar.Server.Features.Topics.Dto;

namespace Kabutar.Server.Features.Topics.Requests.CreateTopic;

public class CreateTopicResponse
{
    public CreateTopicResponse(TopicDto topic)
    {
        Topic = topic;
    }

    public TopicDto Topic { get; }    
}
