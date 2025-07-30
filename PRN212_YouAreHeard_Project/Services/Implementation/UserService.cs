using BussinessObjects;
using Repositories.Implementation;
using Repositories.Interface;
using Services.Interface;

namespace Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;

        public UserService()
        {
            _userRepo = new UserRepository();
        }

        public int Register(User newUser)
        {
            var existingUser = _userRepo.GetUserByEmail(newUser.Email);

            if (existingUser != null)
            {
                throw new Exception("Email already exists.");
            }

            return _userRepo.AddUser(newUser);
        }

        public User Login(string email, string password)
        {
            var user = _userRepo.GetUserByEmail(email);

            if (user == null)
            {
                throw new Exception("User not found.");
            }

            if (user.Password != password)
            {
                throw new Exception("Invalid password.");
            }

            if (user.IsActive == null)
            {
                throw new Exception("Account activation status is unknown.");
            }

            if (user.IsActive == false)
            {
                throw new Exception("Your account is disabled.");
            }

            return user;
        }

        public async Task<int> RegisterAsync(User user)
        {
            return await _userRepo.AddUserAsync(user);
        }
    }
}
