using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PointRobertsSoftware.StarTrek.Domain.Models;

namespace PointRobertsSoftware.StarTrek.Api.Data
{
    public interface IUserRepository : IRepository<User, int>
    {
        IEnumerable<User> FindAll();
        bool UserExists(int id);
        Task<User> InsertUserAsync(User newUser);
    }
}
