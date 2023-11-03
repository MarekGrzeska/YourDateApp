using YourDateApp.Domain.Entities;

namespace YourDateApp.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmail(string email);
        Task RegisterUser(User user);
        Task Commit();
    }
}