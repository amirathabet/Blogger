using Microsoft.EntityFrameworkCore.Migrations;
using System;
namespace QuickApp.Migrations
{
    public partial class AddTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 36, nullable: false),
                },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Categories", x => x.Id);
               }
            );

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "Categories");
        }
    }
}
