using Kabutar.Server.Models;
using MediatR;

namespace Kabutar.Server.Features.Topics.Requests.CreateTopic;

public class CreateTopicRequest : IRequest<CreateTopicResponse>
{
    public CreateTopicRequest(string topicName, string serverUri)
    {
        TopicName = topicName;
        ServerUri = serverUri;
    }

    public string TopicName { get; }
    
    public string ServerUri { get; }
}
