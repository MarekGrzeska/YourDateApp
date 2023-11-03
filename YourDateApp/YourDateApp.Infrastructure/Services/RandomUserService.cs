using Newtonsoft.Json.Linq;

namespace YourDateApp.Infrastructure.Services
{
    public class RandomUserService : IRandomUserService
    {
        private const string BASE_URL = "https://randomuser.me/api/?results=";

        public async Task<JToken?> GetRandomUsers(int usersNum) 
        {
            var url = BASE_URL + usersNum.ToString();

            using (HttpClient client = new HttpClient()) 
            {
                try
                {
                    var response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var jsonObject = JObject.Parse(content);
                        return jsonObject["results"];
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Can't download randomusers from API");
                }
            }
            return null;
        }
    }
}
