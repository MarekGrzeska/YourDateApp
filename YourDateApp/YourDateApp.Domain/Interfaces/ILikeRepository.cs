using YourDateApp.Domain.Entities;

namespace YourDateApp.Domain.Interfaces
{
    public interface ILikeRepository
    {
        Task SendLike(Like like);
    }
}
