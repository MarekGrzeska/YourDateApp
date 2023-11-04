namespace YourDateApp.Application.Dtos
{
    public class LikeDto
    {
        public string UsernameFrom { get; set; } = default!;
        public string UsernameTo { get; set; } = default!;
        public DateTime SentDate { get; set; } = default!;
        public bool IsReceived { get; set; } = default!;
    }
}