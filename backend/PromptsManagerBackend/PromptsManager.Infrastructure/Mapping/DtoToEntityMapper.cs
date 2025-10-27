using AutoMapper;
using PromptsManager.Domain.Dtos;
using PromptsManager.Domain.Entities;

namespace PromptsManager.Infrastructure.Mapping
{
    public class DtoToEntityMapper : Profile
    {
        public DtoToEntityMapper()
        {
            CreateMap<CreatePromptDto, PromptEntity>();
            CreateMap<UpdatePromptDto, PromptEntity>();
            CreateMap<PromptEntity, PromptDto>();
        }
    }
}
