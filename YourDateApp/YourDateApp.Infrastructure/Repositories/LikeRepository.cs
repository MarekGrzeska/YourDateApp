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

        public async Task SendLike(Like like)
        {
            await _dbContext.Likes.AddAsync(like);
            await _dbContext.SaveChangesAsync();
        }
    }
}