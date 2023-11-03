using Newtonsoft.Json.Linq;

namespace YourDateApp.Infrastructure.Services
{
    public class ImageProfileService : IImageProfileService
    {
        public async Task<List<string>> DownloadPhotos(JToken randomUsersJSON)
        {
            var photosUrl = new List<string>();
            foreach (var user in randomUsersJSON) 
            {
                var photoUrl = (string)user["picture"]!["large"]!;
                using (HttpClient client = new HttpClient()) 
                {
                    byte[] image = await client.GetByteArrayAsync(photoUrl);
                    var fileName = Guid.NewGuid().ToString() + ".jpg";
                    var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                    var filePath = Path.Combine(uploadFolder, fileName);
                    File.WriteAllBytes(filePath, image);
                    photosUrl.Add("images/" + fileName);
                }
            }
            return photosUrl;
        }
    }
}
