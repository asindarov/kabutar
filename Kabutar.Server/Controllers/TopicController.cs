using System.Text;
using Kabutar.Server.Dtos;
using Kabutar.Server.Infrastructure;
using Kabutar.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kabutar.Server.Controllers;

[ApiController]
[Route("topics")]
public class TopicController : ControllerBase
{
    private readonly KabutarDbContext _dbContext;

    public TopicController(KabutarDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public async Task<IActionResult> Topic(string topicName, string serverUri)
    {
        var server = await _dbContext.Servers.FirstOrDefaultAsync(server => server.ServerUri == serverUri);

        if (server is null)
        {
            throw new Exception($"{nameof(server)} is not found!");
        }
        
        var doesTopicExistWithTopicName = await _dbContext.Topics.AnyAsync(topic => topic.Name == topicName);

        if (doesTopicExistWithTopicName)
        {
            throw new Exception($"{nameof(Topic)} with topic name - {topicName} is already exists. Please create topic with new name!");
        }

        var topic = new Topic(topicName, server.Id);

        await _dbContext.Topics.AddAsync(topic);

        await _dbContext.SaveChangesAsync();

        return NoContent();
    }

    [HttpPost("{topicName}")]
    public async Task<IActionResult> PublishMessage([FromRoute] string topicName, [FromBody] MessageDto message)
    {
        Console.WriteLine($"Received message for topic: {topicName}. Message : {message.Data}. Server: {message.Topic.Server}");

        var server =
            await _dbContext.Servers.FirstOrDefaultAsync(server => server.ServerUri == message.Topic.Server.ServerUri);

        if (server is null)
        {
            throw new Exception($"{nameof(server)} is not found!");
        }
        
        var topic = 
            await _dbContext.Topics.FirstOrDefaultAsync(topic => topic.Name == message.Topic.Name);

        if (topic is null)
        {
            throw new Exception($"{nameof(topic)} is not found!");
        }

        var newMessage = new Message()
            .FromMessageDto(message)
            .WithTopic(topic)
            .AndWithServer(server);

        await _dbContext.Messages.AddAsync(newMessage);

        await _dbContext.SaveChangesAsync();

        return NoContent();
    }
}
