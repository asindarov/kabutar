using Kabutar.Server.Features.Topics.Dto;
using Kabutar.Server.Models;
using MediatR;

namespace Kabutar.Server.Features.Messages.Requests.PublishMessage;

public class PublishMessageRequest : IRequest<PublishMessageResponse>
{
    public TopicDto Topic { get; set; }
    
    public string Data { get; set; }
}
