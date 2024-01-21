using MediatR;

namespace Kabutar.Server.Features.Messages.Requests.ConsumeMessage;

public class ConsumeMessageRequest : IRequest<ConsumeMessageResponse>
{
    public ConsumeMessageRequest(string topicName)
    {
        TopicName = topicName;  
    }

    public string TopicName { get; }
}
