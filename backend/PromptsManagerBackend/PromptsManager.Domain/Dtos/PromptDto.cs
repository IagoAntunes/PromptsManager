namespace PromptsManager.Domain.Dtos
{
    public class PromptDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
