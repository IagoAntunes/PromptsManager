using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PromptsManager.Core.Utils;
using PromptsManager.Domain.Dtos;
using PromptsManager.Domain.Entities;
using PromptsManager.Domain.Errors;
using PromptsManager.Domain.Repository;
using PromptsManager.Infrastructure.Data;

namespace PromptsManager.Infrastructure
{
    public class PromptRepositoryImpl : IPromptRepository
    {
        private readonly IMapper _mapper;
        private readonly PromptsManagerDbContext _db;
        public PromptRepositoryImpl(
            PromptsManagerDbContext db,
            IMapper mapper
        )
        {
            this._mapper = mapper;
            this._db = db;
        }

        public async Task<ResultBase> CreatePromptAsync(CreatePromptDto promptDto)
        {
            var promptEntity = _mapper.Map<PromptEntity>(promptDto);
            await _db.Prompts.AddAsync(promptEntity);
            await _db.SaveChangesAsync();
            return ResultBase.Success();
        }

        public async Task<ResultBase> Delete(Guid promptId, Guid userId)
        {
            var prompt = await _db.Prompts
                .FirstOrDefaultAsync(p => p.Id == promptId && p.UserId == userId);

            if (prompt == null)
            {
                return ResultBase.Failure(PromptErrors.promptNotFound);
            }

            _db.Prompts.Remove(prompt!);
            await _db.SaveChangesAsync();
            return ResultBase.Success();
        }

        public async Task<ResultOfT<ICollection<PromptEntity>>> GetPromptsByUser(Guid userId)
        {
            var prompts = await _db.Prompts
                .Where(p => p.UserId == userId)
                .ToListAsync();

            return ResultOfT<ICollection<PromptEntity>>.Success(prompts);
        }

        public async Task<ResultOfT<PromptEntity>> Update(UpdatePromptDto prompt,Guid userId)
        {
            var promptEntity = await _db.Prompts
                .FirstOrDefaultAsync(p => p.Id == prompt.Id && p.UserId == userId);

            if(promptEntity == null)
            {
                return ResultOfT<PromptEntity>.Failure(PromptErrors.promptNotFound);
            }

            _db.Entry(promptEntity).CurrentValues.SetValues(prompt);
            promptEntity.UpdatedAt = DateTime.UtcNow;
            await _db.SaveChangesAsync();
            return ResultOfT<PromptEntity>.Success(promptEntity);
        }

    }
}
