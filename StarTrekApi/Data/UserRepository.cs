using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PointRobertsSoftware.StarTrek.Domain.Models;

namespace PointRobertsSoftware.StarTrek.Api.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _dbContext;

        public UserRepository(UserContext context)
        {
            _dbContext = context;
        }

        public Task<User> GetAsync(int id)
        {
            return _dbContext.Users.FindAsync(new object[] { id });
        }

        public void Save(User entity)
        {
            _dbContext.Users.Attach(entity);
        }

        public void Delete(User entity)
        {
            _dbContext.Users.Remove(entity);
        }

        public IEnumerable<User> FindAll()
        {
            return _dbContext.Users.ToList();
        }

        public bool UserExists(int id)
        {
            return _dbContext.Users.FindAsync(id) == null;
        }

        public async Task<User> InsertUserAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            return user;
        }

    }
}
