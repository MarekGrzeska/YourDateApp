using YourDateApp.Domain.Entities;

namespace YourDateApp.Domain.Interfaces
{
    public interface IUserRepository
    {   
        Task<IEnumerable<User>> GetAll();
        Task<User?> GetByEmail(string email);
        Task<User?> GetByUsername(string username);
        Task RegisterUser(User user);
        Task Commit();
    }
}