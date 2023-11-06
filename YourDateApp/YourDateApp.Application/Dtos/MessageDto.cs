namespace YourDateApp.Application.Dtos
{
    public class MessageDto
    {
        public string Content { get; set; } = default!;
        public string UsernameFrom { get; set; } = default!;
        public string UsernameTo { get; set; } = default!;
        public bool? IsReceived { get; set; }
        public DateTime? SentDate { get; set; }
    }
}