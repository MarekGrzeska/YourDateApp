using YourDateApp.Application.Dtos;

namespace YourDateApp.Application.Services
{
    public interface IProfilePhotoService
    {
        string? SavePhoto(UserProfileDto userProfile);
    }
}