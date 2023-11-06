using Microsoft.EntityFrameworkCore;
using YourDateApp.Domain.Entities;
using YourDateApp.Domain.Interfaces;
using YourDateApp.Infrastructure.DbProvider;

namespace YourDateApp.Infrastructure.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly YourDateDbContext _dbContext;

        public MessageRepository(YourDateDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task AddMessage(Message message)
        {
            await _dbContext.Messages.AddAsync(message);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Message>> GetAllMessagesForChatId(int chatId)
        {
            return await _dbContext.Messages.Where(m => m.ChatId == chatId)
                .OrderBy(msg => msg.SentDate).ToListAsync();
        }
    }
}