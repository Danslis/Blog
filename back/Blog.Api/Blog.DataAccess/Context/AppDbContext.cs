using Blog.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blog.DataAccess.Context
{
    public class AppDbContext : IdentityDbContext<UserEntity>
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) { }

        public AppDbContext()
        {
        }

        public DbSet<TestTableEntity> TestTable { get; set; }
        public DbSet<PostEntity> Posts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TestTableConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
