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

        public async Task UpdateUser(int id, User userToUpdate)
        {
            await _userRepository.UpdateUser(id, userToUpdate);
        }
        public int checkpassword(string pwd)
        {
            if (pwd=="")
                return 0;
            var result =  Zxcvbn.Core.EvaluatePassword(pwd);
            return result.Score;
        }
    }
}