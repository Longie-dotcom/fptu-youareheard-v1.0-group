using BussinessObjects;

namespace Repositories.Interface
{
    public interface IUserRepository
    {
        User GetUserByEmail(string email);
        int AddUser(User user);
        Task<int> AddUserAsync(User user);
        int AddUserWithContext(User user, DataAccessLayer.YouAreHeardContext context);
    }
}
