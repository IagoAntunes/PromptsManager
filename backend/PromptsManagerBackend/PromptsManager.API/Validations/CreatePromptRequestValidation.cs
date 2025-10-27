using FluentValidation;
using PromptsManager.Application.Request;

namespace PromptsManager.API.Validations
{
    public class CreatePromptRequestValidation : AbstractValidator<CreatePromptRequest> 
    {
        public CreatePromptRequestValidation()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(256).WithMessage("Title must not exceed 256 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(1024).WithMessage("Description must not exceed 1024 characters.");
        }

    }
}
