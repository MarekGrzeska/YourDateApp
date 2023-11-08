namespace YourDateApp.Application.Dtos
{
    public class ChatDto
    {
        public string UsernameChatWith { get; set; } = default!;
        public string? UsernameChatWithPhotoSrc { get; set; }
        public DateTime LastMessageDate { get; set; } = default!;
        public int NewMessageAmount { get; set; } = default!;
    }
}