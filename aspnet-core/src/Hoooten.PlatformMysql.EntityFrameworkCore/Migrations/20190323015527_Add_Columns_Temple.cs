using Microsoft.EntityFrameworkCore.Migrations;

namespace Hoooten.PlatformMysql.Migrations
{
    public partial class Add_Columns_Temple : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Temples_AbpUsers_RecommendUserId",
                table: "Temples");

            migrationBuilder.DropIndex(
                name: "IX_Temples_RecommendUserId",
                table: "Temples");

            migrationBuilder.DropColumn(
                name: "RecommendUserId",
                table: "Temples");

            migrationBuilder.AddColumn<double>(
                name: "Lat",
                table: "Temples",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Lon",
                table: "Temples",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "Lon",
                table: "ForeFathers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Lat",
                table: "ForeFathers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TempleId",
                table: "ForeFathers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ForeFathers_TempleId",
                table: "ForeFathers",
                column: "TempleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ForeFathers_Temples_TempleId",
                table: "ForeFathers",
                column: "TempleId",
                principalTable: "Temples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForeFathers_Temples_TempleId",
                table: "ForeFathers");

            migrationBuilder.DropIndex(
                name: "IX_ForeFathers_TempleId",
                table: "ForeFathers");

            migrationBuilder.DropColumn(
                name: "Lat",
                table: "Temples");

            migrationBuilder.DropColumn(
                name: "Lon",
                table: "Temples");

            migrationBuilder.DropColumn(
                name: "TempleId",
                table: "ForeFathers");

            migrationBuilder.AddColumn<long>(
                name: "RecommendUserId",
                table: "Temples",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Lon",
                table: "ForeFathers",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "Lat",
                table: "ForeFathers",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.CreateIndex(
                name: "IX_Temples_RecommendUserId",
                table: "Temples",
                column: "RecommendUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Temples_AbpUsers_RecommendUserId",
                table: "Temples",
                column: "RecommendUserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
