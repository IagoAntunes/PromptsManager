using PromptsManager.Application.Request;
using PromptsManager.Core.Utils;
using PromptsManager.Domain.Dtos;

namespace PromptsManager.Application.Service.Interface
{
    public interface IPromptService
    {
        Task<ResultBase> CreatePromptAsync(CreatePromptRequest request, Guid userId);
        Task<ResultOfT<ICollection<PromptDto>>> GetPromptsByUser(Guid userId);
        Task<ResultOfT<PromptDto>> Update(UpdatePromptRequest request, Guid userId);
        Task<ResultBase> Delete(Guid promptId, Guid userId);
    }
}
