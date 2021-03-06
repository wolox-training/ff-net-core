#region Using
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models.Database;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
#endregion

namespace MvcMovie.Repositories.Database
{
    public class DataBaseContext : IdentityDbContext<User>
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) {}

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
