using YourDateApp.Domain.Entities;

namespace YourDateApp.Domain.Interfaces
{
    public interface IChatRepository
    {
        Task AddChat(Chat chat);
        Task<Chat?> FindChatWithUsers(string username1, string username2);
        Task<List<Chat>> GetAllChats(string username);
    }
}