using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using PointRobertsSoftware.StarTrek.Domain.Models;
using PointRobertsSoftware.StarTrek.Api.Data;
using System.Threading.Tasks;
using System.Linq;

namespace PointRobertsSoftware.StarTrek.Api.Tests.TestMocks
{
    public class TestUserRepository : IUserRepository
    {
        public List<User> Users { get; set; }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> FindAll()
        {
            return Users;
        }

        public async Task<User> GetAsync(int id)
        {
            return await Task.Run(() => Users.FirstOrDefault(x => x.Id == id));
        }

        public void Save(User entity)
        {
            throw new NotImplementedException();
        }

        public bool UserExists(int id)
        {
            return Users.Exists(x => x.Id == id);
        }

        public async Task<User> InsertUserAsync(User newUser)
        {
            return await Task.Run(() => newUser) ;
        }
    }
}
