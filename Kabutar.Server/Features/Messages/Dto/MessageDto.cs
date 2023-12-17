using Kabutar.Server.Features.Topics.Dto;

namespace Kabutar.Server.Features.Messages.Dto;

public class MessageDto
{
    public TopicDto Topic { get; set; }
    
    public string Data { get; set; }

    public int OffSet { get; set; }

    public bool IsProcessed { get; set; }
}