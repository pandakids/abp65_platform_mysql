using Microsoft.EntityFrameworkCore.Migrations;

namespace Hoooten.PlatformMysql.Migrations
{
    public partial class Add_Sexy_ForeFather : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sexy",
                table: "ForeFathers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sexy",
                table: "ForeFathers");
        }
    }
}
