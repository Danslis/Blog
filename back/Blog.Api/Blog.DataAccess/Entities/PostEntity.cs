using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.DataAccess.Entities
{
    public class PostEntity
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
    }

    public class PostConfiguration : IEntityTypeConfiguration<PostEntity>
    {

        public void Configure(EntityTypeBuilder<PostEntity> builder)
        {
            builder.ToTable("Posts").HasKey(o => o.Id);
            builder.Property(o => o.Id).IsRequired().HasColumnName("Id").HasColumnType("INTEGER");
            builder.Property(o => o.Title).IsRequired().HasColumnName("Title").HasColumnType("TEXT");
            builder.Property(o => o.Text).IsRequired().HasColumnName("Text").HasColumnType("TEXT");
            builder.Property(o => o.Author).IsRequired().HasColumnName("Author").HasColumnType("TEXT");
            builder.Property(o => o.Date).IsRequired().HasColumnName("Date").HasColumnType("TEXT");

            builder.HasData(
                new PostEntity { Id = 1, Title = "Test1", Text = "Test1 Test1 Test1 Test1 Test1 Test1", Author = "Test@email.com", Date = DateTime.Now},
                new PostEntity { Id = 2, Title = "Test2", Text = "Test2 Test2 Test2 Test2 Test2 Test2", Author = "Test@email.com", Date = DateTime.Now},
                new PostEntity { Id = 3, Title = "Test3", Text = "Test3 Test3 Test3 Test3 Test3 Test3", Author = "Test@email.com", Date = DateTime.Now }
            );
        }
    }
}
