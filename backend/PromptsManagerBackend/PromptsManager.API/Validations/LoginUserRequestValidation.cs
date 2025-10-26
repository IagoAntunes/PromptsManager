using FluentValidation;
using PromptsManager.Application.Request;

namespace PromptsManager.API.Validations
{
    public class LoginUserRequestValidation : AbstractValidator<LoginUserRequest>
    {
        public LoginUserRequestValidation()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.");
        }
    }
}
