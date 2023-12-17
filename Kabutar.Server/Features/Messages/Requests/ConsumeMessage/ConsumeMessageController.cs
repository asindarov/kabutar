using Kabutar.Server.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kabutar.Server.Features.Messages.Requests.ConsumeMessage;

[ApiController]
[Route("topics")]
public class ConsumeMessageController : ControllerBase
{
    private readonly IMediator _mediator;

    public ConsumeMessageController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("{topicName}")]
    public async Task<ConsumeMessageResponse> ConsumeMessages([FromRoute] string topicName, [FromQuery] string serverUri)
    {
        return await _mediator.Send(new ConsumeMessageRequest(serverUri, topicName));
    }
}