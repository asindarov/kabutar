using MediatR;

namespace Kabutar.Server.Features.Messages.Requests.ConsumeMessage;

public class ConsumeMessageRequest : IRequest<ConsumeMessageResponse>
{
    public ConsumeMessageRequest(string serverUri, string topicName)
    {
        ServerUri = serverUri;
        TopicName = topicName;  
    }

    public string ServerUri { get; }
    
    public string TopicName { get; }
}
