namespace YourDateApp.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = default!;
        public string Username { get; set; } = default!;
        public string Gender { get; set; } = default!;
        public string PasswordHash { get; set; } = default!;
        public ProfileInfo? Profile { get; set; }
    }
}