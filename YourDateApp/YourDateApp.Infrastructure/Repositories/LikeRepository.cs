using Microsoft.EntityFrameworkCore;
using YourDateApp.Domain.Entities;
using YourDateApp.Domain.Interfaces;
using YourDateApp.Infrastructure.DbProvider;

namespace YourDateApp.Infrastructure.Repositories
{
    public class LikeRepository : ILikeRepository
    {
        private readonly YourDateDbContext _dbContext;

        public LikeRepository(YourDateDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Like>>? GetUserReceivedLikes(string username)
        {
            return await _dbContext.Likes.Where(l => l.UsernameTo == username).OrderByDescending(l => l.SentDate).ToListAsync();
        }

        public async Task<IEnumerable<Like>>? GetUserSendedLikes(string username)
        {
            return await _dbContext.Likes.Where(l => l.UsernameFrom == username).OrderByDescending(l => l.SentDate).ToListAsync();
        }

        public async Task SendLike(Like like)
        {
            await _dbContext.Likes.AddAsync(like);
            await _dbContext.SaveChangesAsync();
        }
    }
}