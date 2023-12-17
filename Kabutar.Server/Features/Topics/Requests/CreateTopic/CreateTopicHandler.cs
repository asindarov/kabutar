using System.Diagnostics;
using System.Runtime.CompilerServices;
using AutoMapper;
using Kabutar.Server.Features.Topics.Dto;
using Kabutar.Server.Infrastructure;
using Kabutar.Server.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kabutar.Server.Features.Topics.Requests.CreateTopic;

public class CreateTopicHandler : IRequestHandler<CreateTopicRequest, CreateTopicResponse>
{
    private readonly KabutarDbContext _dbContext;
    private readonly IMapper _mapper;

    public CreateTopicHandler(KabutarDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public async Task<CreateTopicResponse> Handle(CreateTopicRequest request, CancellationToken cancellationToken)
    {
        var server = await _dbContext.Servers.FirstOrDefaultAsync(server => server.ServerUri == request.ServerUri, cancellationToken: cancellationToken);

        if (server is null)
        {
            throw new Exception($"{nameof(server)} is not found!");
        }
        
        var doesTopicExistWithTopicName = await _dbContext.Topics.AnyAsync(topic => topic.Name == request.TopicName, cancellationToken: cancellationToken);

        if (doesTopicExistWithTopicName)
        {
            throw new Exception($"{nameof(Topic)} with topic name - {request.TopicName} is already exists. Please create topic with new name!");
        }

        var topic = new Topic(request.TopicName, server.Id);

        await _dbContext.Topics.AddAsync(topic, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return new CreateTopicResponse(_mapper.Map<TopicDto>(topic));
    }
}
