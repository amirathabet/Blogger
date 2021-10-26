using Microsoft.EntityFrameworkCore.Migrations;

namespace QuickApp.Migrations
{
    public partial class AddTableArticles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                 columns: table => new
                 {
                     Id = table.Column<int>(nullable: false),
                     Name = table.Column<string>( nullable: false),
                     Content = table.Column<string>(nullable: true),
                     CategoryId= table.Column<int>(nullable: true),
                     CustomerId = table.Column<int>(nullable: false),
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_Articles", x => x.Id);
                     table.ForeignKey(
                         name: "FK_Articles_Categories_CategoryId",
                         column: x => x.CategoryId,
                         principalTable: "Categories",
                         principalColumn: "Id",
                         onDelete: ReferentialAction.Cascade);
                     table.ForeignKey(
                         name: "FK_Articles_AppCustomers_CustomerId",
                         column: x => x.CustomerId,
                         principalTable: "AppCustomers",
                         principalColumn: "Id",
                         onDelete: ReferentialAction.Cascade);
                 }
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
              name: "Articles");
        }
    }
}
