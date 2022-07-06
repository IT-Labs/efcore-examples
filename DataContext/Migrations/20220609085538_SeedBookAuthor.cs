using Microsoft.EntityFrameworkCore.Migrations;

namespace DataContext.Migrations
{
    public partial class SeedBookAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BookAuthor",
                columns: new[] { "BookId", "AuthorId" },
                values: new[,]
                {
                    { "5", "3" }
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
