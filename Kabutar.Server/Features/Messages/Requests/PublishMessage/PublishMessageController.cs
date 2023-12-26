using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kabutar.Server.Features.Messages.Requests.PublishMessage;

[ApiController]
[Route("topics")]
public class PublishMessageController : ControllerBase
{
    private readonly IMediator _mediator;

    public PublishMessageController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("{topicName}/messages")]
    public async Task<PublishMessageResponse> PublishMessage([FromBody] PublishMessageRequest request)
    {
        return await _mediator.Send(request);
    }
}
