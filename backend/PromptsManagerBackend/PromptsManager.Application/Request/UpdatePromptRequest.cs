namespace PromptsManager.Application.Request
{
    public class UpdatePromptRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
