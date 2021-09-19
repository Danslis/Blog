using Blog.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.DataAccess.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) { }

        public AppDbContext()
        {
        }

        public DbSet<TestTableEntity> TestTable { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<TestTableEntity>().HasData(
                new TestTableEntity { Id = 1, Name = "Test1" },
                new TestTableEntity { Id = 2, Name = "Test2" },
                new TestTableEntity { Id = 3, Name = "Test3" }
            );
        }
    }
}
