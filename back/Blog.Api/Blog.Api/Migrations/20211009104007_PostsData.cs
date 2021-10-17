using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Api.Migrations
{
    public partial class PostsData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    Author = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Author", "Date", "Text", "Title" },
                values: new object[] { 1L, "Test@email.com", new DateTime(2021, 10, 9, 13, 40, 6, 740, DateTimeKind.Local).AddTicks(7236), "Test1 Test1 Test1 Test1 Test1 Test1", "Test1" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Author", "Date", "Text", "Title" },
                values: new object[] { 2L, "Test@email.com", new DateTime(2021, 10, 9, 13, 40, 6, 741, DateTimeKind.Local).AddTicks(8992), "Test2 Test2 Test2 Test2 Test2 Test2", "Test2" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Author", "Date", "Text", "Title" },
                values: new object[] { 3L, "Test@email.com", new DateTime(2021, 10, 9, 13, 40, 6, 741, DateTimeKind.Local).AddTicks(9014), "Test3 Test3 Test3 Test3 Test3 Test3", "Test3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
