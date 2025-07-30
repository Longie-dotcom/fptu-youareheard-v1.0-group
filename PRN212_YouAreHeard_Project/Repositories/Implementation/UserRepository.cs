using BussinessObjects;
using DataAccessLayer;
using Repositories.Interface;

namespace Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        public User GetUserByEmail(string email)
        {
            return UserDAO.GetUserByEmail(email);
        }

        public int AddUser(User user)
        {
            return UserDAO.AddUser(user);
        }

        public async Task<int> AddUserAsync(User user)
        {
            return await UserDAO.AddUserAsync(user);
        }

        public int AddUserWithContext(User user, DataAccessLayer.YouAreHeardContext context)
        {
            return UserDAO.AddUserWithContext(user, context);
        }
    }
}
