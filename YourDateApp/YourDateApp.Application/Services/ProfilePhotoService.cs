using YourDateApp.Application.Dtos;

namespace YourDateApp.Application.Services
{
    public class ProfilePhotoService : IProfilePhotoService
    {
        public string? SavePhoto(UserProfileDto userProfile)
        {
            if (userProfile.PhotoFile == null || userProfile.PhotoFile.Length == 0) return null;
            using (MemoryStream ms = new MemoryStream()) 
            {
                userProfile.PhotoFile.CopyTo(ms);
                var fileName = Guid.NewGuid().ToString() + ".jpg";
                var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                var filePath = Path.Combine(uploadFolder, fileName);
                File.WriteAllBytes(filePath, ms.ToArray());
                return "images/" + fileName;
            }
        }
    }
}