using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PointRobertsSoftware.StarTrek.Api.Models
{
    public partial class StartrekContext : DbContext
    {
        public StartrekContext()
        {
        }

        public StartrekContext(DbContextOptions<StartrekContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {}

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
