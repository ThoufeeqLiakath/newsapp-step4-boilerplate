using Entities;
using System.Threading.Tasks;

namespace Service
{
    public interface IUserService
    {
        Task<bool> AddUser(UserProfile user);
        Task<UserProfile> GetUser(string userId);
        Task<bool> UpdateUser(string userId,UserProfile user);
        Task<bool> DeleteUser(string userId);
    }
}
