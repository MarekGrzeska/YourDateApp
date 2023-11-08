using Microsoft.EntityFrameworkCore;
using YourDateApp.Domain.Entities;
using YourDateApp.Domain.Interfaces;
using YourDateApp.Infrastructure.DbProvider;

namespace YourDateApp.Infrastructure.Repositories
{
    public class ChatRepository : IChatRepository
    {
        private readonly YourDateDbContext _dbContext;

        public ChatRepository(YourDateDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddChat(Chat chat)
        {
            await _dbContext.Chats.AddAsync(chat);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Chat?> FindChatWithUsers(string username1, string username2)
        {
            var chat = await _dbContext.Chats.FirstOrDefaultAsync(c => 
            (c.Username1 == username1 && c.Username2 == username2) ||
            (c.Username1 == username2 && c.Username2 == username1));
            return chat;
        }

        public async Task<List<Chat>> GetAllChats(string username)
        {
            return await _dbContext.Chats
                .Where(c => c.Username1 == username || c.Username2 == username).ToListAsync();
        }
    }
}