using AutoMapper;
using Kabutar.Server.Features.Messages.Dto;
using Kabutar.Server.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kabutar.Server.Features.Messages.Requests.ConsumeMessage;

public class ConsumeMessageHandler : IRequestHandler<ConsumeMessageRequest, ConsumeMessageResponse>
{
    private readonly KabutarDbContext _dbContext;
    private readonly IMapper _mapper;

    public ConsumeMessageHandler(KabutarDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task<ConsumeMessageResponse> Handle(ConsumeMessageRequest request, CancellationToken cancellationToken)
    {
        var topic = 
            await _dbContext.Topics
                .FirstOrDefaultAsync(
                    topic => topic.Name == request.TopicName,
                    cancellationToken: cancellationToken);

        if (topic is null)
        {
            throw new Exception($"{nameof(topic)} is not found!");
        }

        var nonProcessedMessages =
            await _dbContext.Messages
                .Where(message => !message.IsProcessed)
                .ToListAsync(cancellationToken: cancellationToken);
        
        foreach (var nonProcessedMessage in nonProcessedMessages)
        {
            nonProcessedMessage.IsProcessed = true;
        }

        await _dbContext.SaveChangesAsync(cancellationToken);

        return new ConsumeMessageResponse(
            _mapper.ProjectTo<MessageDto>(
                nonProcessedMessages.AsQueryable())
                .ToList());
    }
}
