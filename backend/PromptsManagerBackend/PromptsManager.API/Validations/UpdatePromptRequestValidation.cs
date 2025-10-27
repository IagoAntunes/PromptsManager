using FluentValidation;
using PromptsManager.Application.Request;

namespace PromptsManager.API.Validations
{
    public class UpdatePromptRequestValidation : AbstractValidator<UpdatePromptRequest>
    {
        public UpdatePromptRequestValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Prompt Id is required.");
        }
    }
}
