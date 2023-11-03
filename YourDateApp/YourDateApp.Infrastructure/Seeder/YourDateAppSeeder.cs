using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Newtonsoft.Json.Linq;
using YourDateApp.Domain.Entities;
using YourDateApp.Infrastructure.DbProvider;
using YourDateApp.Infrastructure.Services;

namespace YourDateApp.Infrastructure.Seeder
{
    public class YourDateAppSeeder
    {
        private readonly YourDateDbContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IRandomUserService _randomUserService;
        private readonly IImageProfileService _imageProfileService;
        private const int USERS_NUMBER = 100;

        public YourDateAppSeeder(YourDateDbContext dbContext, IPasswordHasher<User> passwordHasher,
            IRandomUserService randomUserService, IImageProfileService imageProfileService)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
            _randomUserService = randomUserService;
            _imageProfileService = imageProfileService;
        }

        private List<User> CreateRandomUsers(JToken usersJson, List<string> photosSrc)
        {
            int i = 0;
            var usersList = new List<User>();
            foreach (var person in  usersJson) 
            {
                var user = new User
                {
                    Email = (string)person["email"]!,
                    Username = (string)person["login"]!["username"]!,
                    Gender = (string)person["gender"]!,
                    Profile = new ProfileInfo()
                    {
                        FirstName = (string)person["name"]!["first"]!,
                        LastName = (string)person["name"]!["last"]!,
                        Country = (string)person["location"]!["country"]!,
                        City = (string)person["location"]!["city"]!,
                        Age = (int)person["dob"]!["age"]!,
                        PhotoSrc = photosSrc[i],
                    },
                };
                var password = "12345";
                var hashedPassword = _passwordHasher.HashPassword(user, password);
                user.PasswordHash = hashedPassword;
                user.Gender = user.Gender == "male" ? "Mężczyzna" : "Kobieta";
                usersList.Add(user);
                i++;
            }
            return usersList;
        }

        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync()) 
            {
                if (! _dbContext.Users.Any()) 
                {
                    var randomUsersResults = await _randomUserService.GetRandomUsers(USERS_NUMBER);
                    if (randomUsersResults != null)
                    {
                        var profilePhotosSrc = await _imageProfileService.DownloadPhotos(randomUsersResults);
                        var users = CreateRandomUsers(randomUsersResults, profilePhotosSrc);
                        await _dbContext.Users.AddRangeAsync(users);
                        await _dbContext.SaveChangesAsync();
                    }
                }
            }
        }
    }
}
