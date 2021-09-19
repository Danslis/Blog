using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestTable", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TestTable",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Test1" });

            migrationBuilder.InsertData(
                table: "TestTable",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Test2" });

            migrationBuilder.InsertData(
                table: "TestTable",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Test3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestTable");
        }
    }
}
