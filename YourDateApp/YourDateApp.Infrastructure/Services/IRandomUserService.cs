using Newtonsoft.Json.Linq;

namespace YourDateApp.Infrastructure.Services
{
    public interface IRandomUserService
    {
        Task<JToken?> GetRandomUsers(int usersNum);
    }
}
