namespace YourDateApp.Domain.Entities
{
    public class Message
    {
        public int Id { get; set; } = default!;
        public string Content { get; set; } = default!;
        public string UsernameFrom { get; set; } = default!;
        public string UsernameTo { get; set; } = default!;
        public DateTime SentDate { get; set; } = default!;
        public bool IsReceived { get; set; } = default!;
        public Chat Chat { get; set; } = default!;
        public int ChatId { get; set; } = default!;
    }
}