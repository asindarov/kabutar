using Kabutar.Server.Features.Messages.Dto;

namespace Kabutar.Server.Features.Messages.Requests.ConsumeMessage;

public class ConsumeMessageResponse
{
    public ConsumeMessageResponse(IList<MessageDto> messages)
    {
        Messages = messages;
    }

    public IList<MessageDto> Messages { get; }
}
