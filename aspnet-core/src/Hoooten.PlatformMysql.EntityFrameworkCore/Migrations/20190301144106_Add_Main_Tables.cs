using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hoooten.PlatformMysql.Migrations
{
    public partial class Add_Main_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "RecommendUserId",
                table: "Temples",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BornAt",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Century",
                table: "AbpUsers",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DieAt",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FlowersNumber",
                table: "AbpUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GoldNumber",
                table: "AbpUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Lat",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lon",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoveNumber",
                table: "AbpUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MoneyNumber",
                table: "AbpUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "SignDate",
                table: "AbpUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "ForeActivities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Address = table.Column<string>(maxLength: 200, nullable: true),
                    Content = table.Column<string>(maxLength: 200, nullable: true),
                    BinaryObjectId = table.Column<Guid>(nullable: true),
                    TempleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForeActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForeActivities_AppBinaryObjects_BinaryObjectId",
                        column: x => x.BinaryObjectId,
                        principalTable: "AppBinaryObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ForeActivities_Temples_TempleId",
                        column: x => x.TempleId,
                        principalTable: "Temples",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ForeFathers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Century = table.Column<string>(maxLength: 10, nullable: true),
                    BornAt = table.Column<DateTime>(nullable: true),
                    DieAt = table.Column<DateTime>(nullable: true),
                    LoveNumber = table.Column<int>(nullable: false),
                    FlowersNumber = table.Column<int>(nullable: false),
                    MoneyNumber = table.Column<int>(nullable: false),
                    GoldNumber = table.Column<int>(nullable: false),
                    Lon = table.Column<string>(nullable: true),
                    Lat = table.Column<string>(nullable: true),
                    Marks = table.Column<string>(maxLength: 500, nullable: true),
                    BinaryObjectId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForeFathers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForeFathers_AppBinaryObjects_BinaryObjectId",
                        column: x => x.BinaryObjectId,
                        principalTable: "AppBinaryObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TempleMembers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Marks = table.Column<string>(maxLength: 200, nullable: true),
                    IsApproved = table.Column<bool>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    TempleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempleMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TempleMembers_Temples_TempleId",
                        column: x => x.TempleId,
                        principalTable: "Temples",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TempleMembers_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGifts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TheGiftType = table.Column<int>(nullable: false),
                    GiftNumber = table.Column<int>(nullable: false),
                    SignDate = table.Column<DateTime>(nullable: true),
                    GiftSource = table.Column<int>(nullable: false),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGifts_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ForeFatherGifts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TheGiftType = table.Column<int>(nullable: false),
                    GiftNumber = table.Column<int>(nullable: false),
                    ForeFatherId = table.Column<int>(nullable: false),
                    UserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForeFatherGifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForeFatherGifts_ForeFathers_ForeFatherId",
                        column: x => x.ForeFatherId,
                        principalTable: "ForeFathers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ForeFatherGifts_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Temples_RecommendUserId",
                table: "Temples",
                column: "RecommendUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ForeActivities_BinaryObjectId",
                table: "ForeActivities",
                column: "BinaryObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ForeActivities_TempleId",
                table: "ForeActivities",
                column: "TempleId");

            migrationBuilder.CreateIndex(
                name: "IX_ForeFatherGifts_ForeFatherId",
                table: "ForeFatherGifts",
                column: "ForeFatherId");

            migrationBuilder.CreateIndex(
                name: "IX_ForeFatherGifts_UserId",
                table: "ForeFatherGifts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ForeFathers_BinaryObjectId",
                table: "ForeFathers",
                column: "BinaryObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TempleMembers_TempleId",
                table: "TempleMembers",
                column: "TempleId");

            migrationBuilder.CreateIndex(
                name: "IX_TempleMembers_UserId",
                table: "TempleMembers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGifts_UserId",
                table: "UserGifts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Temples_AbpUsers_RecommendUserId",
                table: "Temples",
                column: "RecommendUserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Temples_AbpUsers_RecommendUserId",
                table: "Temples");

            migrationBuilder.DropTable(
                name: "ForeActivities");

            migrationBuilder.DropTable(
                name: "ForeFatherGifts");

            migrationBuilder.DropTable(
                name: "TempleMembers");

            migrationBuilder.DropTable(
                name: "UserGifts");

            migrationBuilder.DropTable(
                name: "ForeFathers");

            migrationBuilder.DropIndex(
                name: "IX_Temples_RecommendUserId",
                table: "Temples");

            migrationBuilder.DropColumn(
                name: "RecommendUserId",
                table: "Temples");

            migrationBuilder.DropColumn(
                name: "BornAt",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "Century",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "DieAt",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "FlowersNumber",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "GoldNumber",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "Lat",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "Lon",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "LoveNumber",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "MoneyNumber",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "SignDate",
                table: "AbpUsers");
        }
    }
}
