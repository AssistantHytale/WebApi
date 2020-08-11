using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AssistantHytale.Api.Migrations
{
    public partial class AddGuideTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatDateTime",
                table: "Servers");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDateTime",
                table: "Servers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "GuideDetails",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    ShortTitle = table.Column<string>(nullable: false),
                    Translator = table.Column<string>(nullable: false),
                    Minutes = table.Column<int>(nullable: false),
                    Tags = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuideDetails", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "GuideMetas",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    Likes = table.Column<int>(nullable: false),
                    Views = table.Column<int>(nullable: false),
                    ShowCreatedByUser = table.Column<bool>(nullable: false),
                    UserGuid = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuideMetas", x => x.Guid);
                    table.ForeignKey(
                        name: "ForeignKey_User_GuideMetas",
                        column: x => x.UserGuid,
                        principalTable: "Users",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GuideContents",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuideContents", x => x.Guid);
                    table.ForeignKey(
                        name: "ForeignKey_Content_GuideDetails",
                        column: x => x.Guid,
                        principalTable: "GuideDetails",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GuideMetaGuideDetails",
                columns: table => new
                {
                    GuideMetaGuid = table.Column<Guid>(nullable: false),
                    GuideDetailGuid = table.Column<Guid>(nullable: false),
                    LanguageType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuideMetaGuideDetails", x => new { x.GuideMetaGuid, x.GuideDetailGuid, x.LanguageType });
                    table.ForeignKey(
                        name: "ForeignKey_GuideMetaGuideDetails_GuideDetails",
                        column: x => x.GuideDetailGuid,
                        principalTable: "GuideDetails",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "ForeignKey_GuideMetaGuideDetails_GuideMetas",
                        column: x => x.GuideMetaGuid,
                        principalTable: "GuideMetas",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GuideMetaGuideDetails_GuideDetailGuid",
                table: "GuideMetaGuideDetails",
                column: "GuideDetailGuid");

            migrationBuilder.CreateIndex(
                name: "IX_GuideMetas_UserGuid",
                table: "GuideMetas",
                column: "UserGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuideContents");

            migrationBuilder.DropTable(
                name: "GuideMetaGuideDetails");

            migrationBuilder.DropTable(
                name: "GuideDetails");

            migrationBuilder.DropTable(
                name: "GuideMetas");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreateDateTime",
                table: "Servers");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatDateTime",
                table: "Servers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
