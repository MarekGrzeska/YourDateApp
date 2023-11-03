using Newtonsoft.Json.Linq;

namespace YourDateApp.Infrastructure.Services
{
    public interface IImageProfileService
    {
        Task<List<string>> DownloadPhotos(JToken randomUsersJSON);
    }
}
