using AutoMapper;
using Kabutar.Server.Features.Messages.Dto;
using Kabutar.Server.Features.Servers.Dto;
using Kabutar.Server.Features.Topics.Dto;
using Kabutar.Server.Models;

namespace Kabutar.Server.Features.Messages;

public class MessageProfile : Profile
{
    public MessageProfile()
    {
        CreateMap<Message, MessageDto>();
        CreateMap<Topic, TopicDto>();
        CreateMap<Models.Server, ServerDto>();
    }
}