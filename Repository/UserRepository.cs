using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MyStoreContext _myStoreContext;

        public UserRepository(MyStoreContext myStoreContext)
        {
            _myStoreContext = myStoreContext;
        }


        public async Task<User> AddUser(User user)
        {
            await _myStoreContext.Users.AddAsync(user);
            await _myStoreContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUserByEmailAndPassword(string email, string password)
        {
            return await _myStoreContext.Users.Where(user => user.Email == email && user.Password == password).FirstOrDefaultAsync();
             
        }

        public async Task UpdateUser(int id, User userToUpdate)
        {
            _myStoreContext.Users.Update(userToUpdate);
            await _myStoreContext.SaveChangesAsync();
        }
    }
}
