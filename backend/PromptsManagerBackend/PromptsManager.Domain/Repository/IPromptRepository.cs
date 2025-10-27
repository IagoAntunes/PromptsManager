using PromptsManager.Core.Utils;
using PromptsManager.Domain.Dtos;
using PromptsManager.Domain.Entities;

namespace PromptsManager.Domain.Repository
{
    public interface IPromptRepository
    {
        Task<ResultBase> CreatePromptAsync(CreatePromptDto promptDto);
        Task<ResultOfT<ICollection<PromptEntity>>> GetPromptsByUser(Guid userId);
        Task<ResultOfT<PromptEntity>> Update(UpdatePromptDto prompt, Guid userId);
        Task<ResultBase> Delete(Guid promptId, Guid userId);
    }
}
