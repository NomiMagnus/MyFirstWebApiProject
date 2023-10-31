using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        private const string filePath = "users.txt";
        public async Task<User> AddUser(User user)
        {
            int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            user.userId = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            await System.IO.File.AppendAllTextAsync(filePath, userJson + Environment.NewLine);
            return user;
        }

        public async Task<User> GetUserByEmailAndPassword(string email, string password)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = await reader.ReadLineAsync()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user?.email == email && user?.password == password)
                        return user;
                }
            }
            return null;
        }

        public async Task<bool> UpdateUser(int id, User userToUpdate)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string currentUserInFile;
                while ((currentUserInFile = await reader.ReadLineAsync()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.userId == id)
                        textToReplace = currentUserInFile;
                }
            }

            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(filePath);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(userToUpdate));
                await System.IO.File.WriteAllTextAsync(filePath, text);
                return true;
            }
            return false;
        }
    }
}
