using Entities;

namespace Services
{
    public interface IUserService
    {
        User AddUser(User user);
        int checkpassword(string pwd);
        User GetUserByUserNameAndPassword(string email, string password);
        bool UpdateUser(int id, User userToUpdate);
    }
}