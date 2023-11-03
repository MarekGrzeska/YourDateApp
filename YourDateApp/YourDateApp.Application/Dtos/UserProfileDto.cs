using Microsoft.AspNetCore.Http;

namespace YourDateApp.Application.Dtos
{
    public class UserProfileDto
    {
        public int Id { get; set; }
        public string Email { get; set; } = default!;
        public string Username { get; set; } = default!;
        public string Gender { get; set; } = default!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhotoSrc { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public int? Age { get; set; }
        public IFormFile? PhotoFile { get; set; }
    }
}