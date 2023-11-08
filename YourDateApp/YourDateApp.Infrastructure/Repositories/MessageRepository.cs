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

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddMessage(Message message)
        {
            await _dbContext.Messages.AddAsync(message);
            await Commit();
        }

        public async Task<List<Message>> GetAllMessagesForChatId(int chatId)
        {
            return await _dbContext.Messages.Where(m => m.ChatId == chatId)
                .OrderBy(msg => msg.SentDate).ToListAsync();
        }

        public async Task<List<Message>> GetNewMessages(string usernameFrom, string usernameTo)
        {
            return await _dbContext.Messages.Where(m => m.UsernameFrom == usernameFrom 
            && m.UsernameTo == usernameTo && m.IsReceived == false).ToListAsync();
        }

        public async Task SetMessageReceived(string usernameFrom, string usernameTo)
        {
            var messages = await _dbContext.Messages.Where(m => m.UsernameFrom == usernameFrom
            && m.UsernameTo == usernameTo && m.IsReceived == false).ToListAsync();

            foreach (var message in messages) 
            {
                message.IsReceived = true;
            }
            await Commit();
        }

        public async Task<int> GetAllNewMessagesCount(string username)
        {
            return await _dbContext.Messages
                .CountAsync(m => m.UsernameTo == username && m.IsReceived == false);
        }
    }
}