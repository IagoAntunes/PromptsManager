namespace PromptsManager.Domain.Dtos
{
    public class CreatePromptDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
    }
}
