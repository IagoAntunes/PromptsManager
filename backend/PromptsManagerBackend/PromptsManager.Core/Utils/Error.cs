using Microsoft.AspNetCore.Http;

namespace PromptsManager.Core.Utils
{
    public readonly record struct Error(string Code, string Description, int StatusCode = StatusCodes.Status400BadRequest)
    {
        public static readonly Error None = new("", "", StatusCodes.Status200OK);
        public static readonly Error BadRequest = new(
            "bad_request",
            "",
            StatusCodes.Status400BadRequest);
        public static readonly Error NotFound = new(
            "not_found",
            "O recurso solicitado não foi encontrado.",
            StatusCodes.Status404NotFound);

        public static readonly Error InvalidObjectId = new(
            "invalid_object_id",
            "O id informado não é válido para o MongoDB.",
            StatusCodes.Status400BadRequest);

        public static readonly Error DuplicateTicket = new(
            "duplicate_ticket",
            "Já existe um ticket para essa categoria.",
            StatusCodes.Status409Conflict);

        public static readonly Error Unauthorized = new(
            "unauthorized",
            "Usuário não autorizado.",
            StatusCodes.Status401Unauthorized);

        public static Error Custom(string code, string description, int statusCode = StatusCodes.Status400BadRequest)
            => new(code, description, statusCode);
    }
}
