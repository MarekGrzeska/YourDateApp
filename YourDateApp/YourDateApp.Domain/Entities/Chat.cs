namespace YourDateApp.Domain.Entities
{
    public class Chat
    {
        public int Id { get; set; } = default!;
        public string Username1 { get; set; } = default!;
        public string Username2 { get; set; } = default!;
        public List<Message> Messages { get; set; } = new();
    }
}