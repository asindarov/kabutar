using Kabutar.Server.Models;
using MediatR;

namespace Kabutar.Server.Features.Topics.Requests.CreateTopic;

public class CreateTopicRequest : IRequest<CreateTopicResponse>
{
    public CreateTopicRequest(string topicName)
    {
        TopicName = topicName;
    }

    public string TopicName { get; }
}
