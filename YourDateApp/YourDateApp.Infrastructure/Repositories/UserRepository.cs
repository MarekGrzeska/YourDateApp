using Microsoft.EntityFrameworkCore;
using YourDateApp.Domain.Entities;
using YourDateApp.Domain.Interfaces;
using YourDateApp.Infrastructure.DbProvider;

namespace YourDateApp.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly YourDateDbContext _dbContext;

        public UserRepository(YourDateDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task RegisterUser(User user)
        {
            await _dbContext.AddAsync(user);
            await Commit();
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
