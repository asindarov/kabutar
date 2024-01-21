using AutoMapper;
using Kabutar.Server.Features.Messages.Dto;
using Kabutar.Server.Infrastructure;
using Kabutar.Server.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kabutar.Server.Features.Messages.Requests.PublishMessage;

public class PublishMessageHandler : IRequestHandler<PublishMessageRequest, PublishMessageResponse>
{
    private readonly KabutarDbContext _dbContext;
    private readonly IMapper _mapper;

    public PublishMessageHandler(KabutarDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task<PublishMessageResponse> Handle(PublishMessageRequest request, CancellationToken cancellationToken)
    {
        var topic = 
            await _dbContext.Topics.FirstOrDefaultAsync(topic => topic.Name == request.Topic.Name, cancellationToken: cancellationToken);

        if (topic is null)
        {
            throw new Exception($"{nameof(topic)} is not found!");
        }

        var newMessage = new Message()
            .FromPublishMessageRequest(request)
            .WithTopic(topic);

        await _dbContext.Messages.AddAsync(newMessage, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);

        var message = _mapper.Map<MessageDto>(newMessage);
        return new PublishMessageResponse(message);
    }
}