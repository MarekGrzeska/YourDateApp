namespace YourDateApp.Domain.Entities
{
    public class Like
    {
        public int Id { get; set; } = default!;
        public string UsernameFrom { get; set; } = default!;
        public string UsernameTo { get; set; } = default!;
        public DateTime SentDate { get; set; } = default!;
        public bool IsReceived { get; set; } = default!;
    }
}