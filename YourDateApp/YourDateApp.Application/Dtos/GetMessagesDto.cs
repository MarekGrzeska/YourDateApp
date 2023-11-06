namespace YourDateApp.Application.Dtos
{
    public class GetMessagesDto
    {
        public string UsernameFrom { get; set; } = default!;
        public string UsernameTo { get; set; } = default!;
    }
}