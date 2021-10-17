using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.DataAccess.Entities
{
    public class TestTableEntity
    {
        public int Id { get; set; }
        public string Name  { get; set; }
        
    }
    public class TestTableConfiguration: IEntityTypeConfiguration<TestTableEntity>
    {      

        public void Configure(EntityTypeBuilder<TestTableEntity> builder)
        {
            builder.ToTable("TestTable").HasKey(o => o.Id);
            builder.Property(o => o.Id).IsRequired().HasColumnName("Id").HasColumnType("INTEGER");
            builder.Property(o => o.Name).IsRequired().HasColumnName("Name").HasColumnType("TEXT");

            builder.HasData(
                new TestTableEntity { Id = 1, Name = "Test1" },
                new TestTableEntity { Id = 2, Name = "Test2" },
                new TestTableEntity { Id = 3, Name = "Test3" }
            );
        }
    }
}
