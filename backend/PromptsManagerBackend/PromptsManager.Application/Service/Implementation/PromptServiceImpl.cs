using AutoMapper;
using PromptsManager.Application.Request;
using PromptsManager.Application.Service.Interface;
using PromptsManager.Core.Utils;
using PromptsManager.Domain.Dtos;
using PromptsManager.Domain.Repository;

namespace PromptsManager.Application.Service.Implementation
{
    public class PromptServiceImpl : IPromptService
    {
        private readonly IPromptRepository _promptRepository;
        private readonly IMapper _mapper;

        public PromptServiceImpl(
            IPromptRepository promptRepository,
            IMapper mapper
        )
        {
            this._promptRepository = promptRepository;
            this._mapper = mapper;
        }

        public Task<ResultBase> CreatePromptAsync(CreatePromptRequest request, Guid userId)
        {
            var promptDto = _mapper.Map<CreatePromptDto>(request);
            promptDto.UserId = userId;
            return _promptRepository.CreatePromptAsync(promptDto);
        }

        public async Task<ResultBase> Delete(Guid promptId, Guid userId)
        {
            var result = await _promptRepository.Delete(promptId, userId);
            return result;
        }

        public async Task<ResultOfT<ICollection<PromptDto>>> GetPromptsByUser(Guid userId)
        {
            var result = await _promptRepository.GetPromptsByUser(userId);

            var promptDtos = _mapper.Map<ICollection<PromptDto>>(result.Value);

            return ResultOfT<ICollection<PromptDto>>.Success(promptDtos);
        }

        public async Task<ResultOfT<PromptDto>> Update(UpdatePromptRequest request, Guid userId)
        {
            var promptDto = _mapper.Map<UpdatePromptDto>(request);
            var result = await _promptRepository.Update(promptDto, userId);

            if(result.IsSuccess)
            {
                var updatedPromptDto = _mapper.Map<PromptDto>(result.Value);
                return ResultOfT<PromptDto>.Success(updatedPromptDto);
            }
            return ResultOfT<PromptDto>.Failure(result.Error);
        }
    }
}
