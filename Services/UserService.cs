using Entities;
using Repository;


namespace Services
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User AddUser(User user)
        {
            return _userRepository.AddUser(user);
        }

        public User GetUserByUserNameAndPassword(string email, string password)
        {
            return _userRepository.GetUserByEmailAndPassword(email, password);
        }

        public bool UpdateUser(int id, User userToUpdate)
        {
            return _userRepository.UpdateUser(id, userToUpdate);
        }
        public int checkpassword(string pwd)
        {
            var result = Zxcvbn.Core.EvaluatePassword(pwd);
            return result.Score;
        }
    }
}