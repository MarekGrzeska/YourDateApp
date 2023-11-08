using YourDateApp.Domain.Entities;

namespace YourDateApp.Domain.Interfaces
{
    public interface IMessageRepository
    {
        Task AddMessage(Message message);
        Task<List<Message>> GetAllMessagesForChatId(int chatId);
        Task SetMessageReceived(string usernameFrom, string usernameTo);
    }
}
