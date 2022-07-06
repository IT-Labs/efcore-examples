using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;

namespace DataContext.Migrations
{
    public partial class SeedBooksAuthors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books", 
                columns: new[] { "Name" }, 
                values: new[,]
                {
                    { "Kniga2" }
                } 
            );

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "FirstName", "LastName" },
                values: new[,]
                {
                    { "Nick", "John" }
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
