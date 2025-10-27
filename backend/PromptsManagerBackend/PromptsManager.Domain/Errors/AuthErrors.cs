using Microsoft.AspNetCore.Http;
using PromptsManager.Core.Utils;

namespace PromptsManager.Domain.Errors
{
    public class AuthErrors
    {
        public static readonly Error InvalidCredentials = new Error(
            "invalid_credentials",
            "Email ou Senha inválidos",
            StatusCodes.Status401Unauthorized
        );
        public static readonly Error EmailAlreadyVinculated = new Error(
            "email_already_vinculated",
            "Email já vinculado a um usuário",
            StatusCodes.Status400BadRequest
        );

        public static readonly Error BlockedAttempts = new Error(
            "blocked_attempts",
            "Conta bloqueada por tentativas erradas",
            StatusCodes.Status400BadRequest
        );

    }
}
