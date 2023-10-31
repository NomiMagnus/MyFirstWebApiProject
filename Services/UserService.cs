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

        public async Task<User> AddUser(User user)
        {
            return await _userRepository.AddUser(user);
        }

        public async Task<User> GetUserByUserNameAndPassword(string email, string password)
        {
            return await _userRepository.GetUserByEmailAndPassword(email, password);
        }

        public async Task<bool> UpdateUser(int id, User userToUpdate)
        {
            return await _userRepository.UpdateUser(id, userToUpdate);
        }
        public int checkpassword(string pwd)
        {
            var result =  Zxcvbn.Core.EvaluatePassword(pwd);
            return result.Score;
        }
    }
}