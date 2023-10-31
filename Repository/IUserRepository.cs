using Entities;

namespace Repository
{
    public interface IUserRepository
    {
        User AddUser(User user);
        User GetUserByEmailAndPassword(string email, string password);
        bool UpdateUser(int id, User userToUpdate);
    }
}