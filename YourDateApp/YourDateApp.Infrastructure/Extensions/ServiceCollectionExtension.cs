using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YourDateApp.Infrastructure.DbProvider;
using YourDateApp.Infrastructure.Seeder;
using YourDateApp.Infrastructure.Services;

namespace YourDateApp.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("YourDateAppDb");
            services.AddDbContext<YourDateDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IRandomUserService, RandomUserService>();
            services.AddScoped<IImageProfileService, ImageProfileService>();
            services.AddScoped<YourDateAppSeeder>();
        }
    }
}
