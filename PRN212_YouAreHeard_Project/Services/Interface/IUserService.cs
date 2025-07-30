using BussinessObjects;

namespace Services.Interface
{
    public interface IUserService
    {
        int Register(User newUser);
        User Login(string email, string password);
        Task<int> RegisterAsync(User user);
    }
}
