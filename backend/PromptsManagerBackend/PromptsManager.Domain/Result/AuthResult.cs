namespace PromptsManager.Domain.Result
{
    public class AuthResult
    {
        public string AccessToken { get; set; } = null!;
        public DateTimeOffset AccessTokenExpires { get; set; }
    }
}
