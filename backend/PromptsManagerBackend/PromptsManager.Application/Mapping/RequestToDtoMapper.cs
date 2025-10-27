using AutoMapper;
using PromptsManager.Application.Request;
using PromptsManager.Domain.Dtos;

namespace PromptsManager.Application.Mapping
{
    public class RequestToDtoMapper : Profile
    {
        public RequestToDtoMapper()
        {
            CreateMap<CreatePromptRequest, CreatePromptDto>();
            CreateMap<UpdatePromptRequest, UpdatePromptDto>();
        }
    }
}
