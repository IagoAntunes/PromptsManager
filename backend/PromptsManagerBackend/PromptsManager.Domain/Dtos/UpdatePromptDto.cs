namespace PromptsManager.Domain.Dtos
{
    public class UpdatePromptDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
