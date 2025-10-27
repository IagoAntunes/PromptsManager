using Microsoft.AspNetCore.Http;
using PromptsManager.Core.Utils;

namespace PromptsManager.Domain.Errors
{
    public class PromptErrors
    {

        public static readonly Error promptNotFound = new Error(
            "prompt_not_found",
            "Prompt não encontrado",
            StatusCodes.Status404NotFound
        );
    }
}
