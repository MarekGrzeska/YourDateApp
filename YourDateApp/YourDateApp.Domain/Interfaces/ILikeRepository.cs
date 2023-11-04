using YourDateApp.Domain.Entities;

namespace YourDateApp.Domain.Interfaces
{
    public interface ILikeRepository
    {
        Task Commit();
        Task SendLike(Like like);
        Task<IEnumerable<Like>>? GetUserReceivedLikes(string username);
        Task<IEnumerable<Like>>? GetUserSendedLikes(string username);
    }
}