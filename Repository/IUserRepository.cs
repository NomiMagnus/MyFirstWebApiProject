using Entities;

namespace Repository
{
    public interface IUserRepository
    {
        Task<User> AddUser(User user);
        Task<User> GetUserByEmailAndPassword(string email, string password);
        Task UpdateUser(int id, User userToUpdate);
    }
}