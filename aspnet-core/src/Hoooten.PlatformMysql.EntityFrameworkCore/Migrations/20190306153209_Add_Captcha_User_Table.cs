using Microsoft.EntityFrameworkCore.Migrations;

namespace Hoooten.PlatformMysql.Migrations
{
    public partial class Add_Captcha_User_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Captcha",
                table: "AbpUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Captcha",
                table: "AbpUsers");
        }
    }
}
