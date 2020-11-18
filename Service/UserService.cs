using DAL;
using Entities;
using Service.Exceptions;
using System.Threading.Tasks;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repository;
        public UserService(IUserRepository userRepository)
        {
            repository = userRepository;
        }
        public async Task<bool> AddUser(UserProfile user)
        {
            var _user =await repository.GetUser(user.UserId);
            if (_user == null)
                return await repository.AddUser(user);
            else
                throw new UserAlreadyExistsException($"{user.UserId} already exists");
        }

        public async Task<bool> DeleteUser(string userId)
        {
            var user =await repository.GetUser(userId);
            if (user != null)
                return await repository.DeleteUser(user);
            else
                throw new UserNotFoundException($"{userId} doesn't exist");
        }

        public async Task<UserProfile> GetUser(string userId)
        {
            var user= await repository.GetUser(userId);
            if (user != null)
                return user;
            else
                throw new UserNotFoundException($"{userId} doesn't exist");
        }

        public async Task<bool> UpdateUser(string userId,UserProfile user)
        {
            var _user = await repository.GetUser(userId);
            if (_user != null)
            {
                _user.Email = user.Email;
                _user.Contact = user.Contact;
                return await repository.UpdateUser(_user);
            }
            else
                throw new UserNotFoundException($"{userId} doesn't exist");
        }
    }
}
