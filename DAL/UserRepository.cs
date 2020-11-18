using Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace DAL
{
    //Inherit the respective interface and implement the methods in 
    // this class i.e UserRepository by inheriting IUserRepository

    // UserRepository class is used to implement all Data access operations
    public class UserRepository : IUserRepository
    {
        private readonly NewsDbContext _dbContext;
        public UserRepository(NewsDbContext dbContext)
        {
            // Implement AddUser method which should be used to save a new user.   
            // Implement DeleteUser method which should be used to delete an existing user.
            // Implement GetUser method which should be used to get a userprofile complete detail by userId.
            // Implement UpdateUser method which should be used to update an existing user.
            _dbContext = dbContext;
        }

        public Task<bool> AddUser(UserProfile user)
        {
            _dbContext.Users.Add(user);
            return Task.FromResult(_dbContext.SaveChanges() > 0);
        }

        public Task<bool> DeleteUser(UserProfile user)
        {
            _dbContext.Users.Remove(user);            
            return Task.FromResult(_dbContext.SaveChanges()>0);
        }

        public Task<UserProfile> GetUser(string userId)
        {
            //var list = _dbContext.Users.ToList();
            var result = _dbContext.Users.Where(x => x.UserId == userId).FirstOrDefault();
            return Task.FromResult(result);
        }

        public Task<bool> UpdateUser(UserProfile user)
        {
            _dbContext.Users.Update(user);
            return Task.FromResult(_dbContext.SaveChanges()>0);
        }
    }
}
