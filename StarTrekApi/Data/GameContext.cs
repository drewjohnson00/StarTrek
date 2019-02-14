using Microsoft.EntityFrameworkCore;
using PointRobertsSoftware.StarTrek.Domain.Models;

namespace PointRobertsSoftware.StarTrek.Api.Data
{
    public class GameContext : DbContext
    {
        public GameContext(DbContextOptions<UserContext> options) : base(options)
        {

        }

        public DbSet<Game> Games { get; set; }
    }
}
