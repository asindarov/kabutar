using Kabutar.Server.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kabutar.Server.Features.Topics.Requests.CreateTopic;

[ApiController]
[Route("topics")]
public class CreateTopicController : ControllerBase
{
    private readonly IMediator _mediator;

    public CreateTopicController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<CreateTopicResponse> CreateTopic(CreateTopicRequest request)
    {
        return await _mediator.Send(request);
    }
}
