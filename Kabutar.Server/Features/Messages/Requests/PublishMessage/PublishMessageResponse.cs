using Kabutar.Server.Features.Messages.Dto;

namespace Kabutar.Server.Features.Messages.Requests.PublishMessage;

public class PublishMessageResponse
{
    public PublishMessageResponse(MessageDto message)
    {
        Message = message;
    }

    public MessageDto Message { get; }
}