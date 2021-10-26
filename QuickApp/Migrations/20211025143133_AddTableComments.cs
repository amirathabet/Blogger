using Microsoft.EntityFrameworkCore.Migrations;

namespace QuickApp.Migrations
{
    public partial class AddTableComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                 columns: table => new
                 {
                     Id = table.Column<int>(nullable: false),
                     Content = table.Column<string>(nullable: true),
                     ArticleId = table.Column<int>(nullable: false),
                     CustomerId = table.Column<int>(nullable: false),
                     IsApproved=table.Column<bool>(defaultValue:false),
                     Reason = table.Column<string>(nullable: true),
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_Comments", x => x.Id);
                     table.ForeignKey(
                         name: "FK_Comments_Articles_ArticleId",
                         column: x => x.ArticleId,
                         principalTable: "Articles",
                         principalColumn: "Id",
                         onDelete: ReferentialAction.Cascade);
                     table.ForeignKey(
                         name: "FK_Comments_AppCustomers_CustomerId",
                         column: x => x.CustomerId,
                         principalTable: "AppCustomers",
                         principalColumn: "Id",
                         onDelete: ReferentialAction.NoAction);
                 }
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name : "Comments"
                );
        }
    }
}
