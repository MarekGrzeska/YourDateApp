using YourDateApp.Domain.Entities;

namespace YourDateApp.Domain.Interfaces
{
    public interface IMessageRepository
    {
        Task Commit();
        Task AddMessage(Message message);
        Task<List<Message>> GetAllMessagesForChatId(int chatId);
        Task<List<Message>> GetNewMessages(string usernameFrom, string usernameTo);
        Task<int> GetAllNewMessagesCount(string username);
        Task SetMessageReceived(string usernameFrom, string usernameTo);
    }
}
