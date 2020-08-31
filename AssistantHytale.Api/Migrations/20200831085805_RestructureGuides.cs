using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AssistantHytale.Api.Migrations
{
    public partial class RestructureGuides : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "ForeignKey_UserPermissions_Permissions",
                table: "UserPermission");

            migrationBuilder.DropTable(
                name: "GuideMetaGuideDetails");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "GuideMetas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPermission",
                table: "UserPermission");

            migrationBuilder.DropIndex(
                name: "IX_UserPermission_PermissionType",
                table: "UserPermission");

            migrationBuilder.DropColumn(
                name: "ShortTitle",
                table: "GuideDetails");

            migrationBuilder.DropColumn(
                name: "Translator",
                table: "GuideDetails");

            migrationBuilder.RenameTable(
                name: "UserPermission",
                newName: "UserPermissions");

            migrationBuilder.AddColumn<bool>(
                name: "ShowCreatedByUser",
                table: "Servers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "UserGuid",
                table: "Servers",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                table: "GuideDetails",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "GuideDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "OriginalGuideGuid",
                table: "GuideDetails",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "ShowCreatedByUser",
                table: "GuideDetails",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "GuideDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SubTitle",
                table: "GuideDetails",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "TranslatorGuid",
                table: "GuideDetails",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserGuid",
                table: "GuideDetails",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Views",
                table: "GuideDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPermissions",
                table: "UserPermissions",
                columns: new[] { "UserGuid", "PermissionType" });

            migrationBuilder.CreateIndex(
                name: "IX_Servers_UserGuid",
                table: "Servers",
                column: "UserGuid");

            migrationBuilder.CreateIndex(
                name: "IX_GuideDetails_UserGuid",
                table: "GuideDetails",
                column: "UserGuid");

            migrationBuilder.AddForeignKey(
                name: "ForeignKey_User_GuideDetails",
                table: "GuideDetails",
                column: "UserGuid",
                principalTable: "Users",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "ForeignKey_User_Servers",
                table: "Servers",
                column: "UserGuid",
                principalTable: "Users",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "ForeignKey_User_GuideDetails",
                table: "GuideDetails");

            migrationBuilder.DropForeignKey(
                name: "ForeignKey_User_Servers",
                table: "Servers");

            migrationBuilder.DropIndex(
                name: "IX_Servers_UserGuid",
                table: "Servers");

            migrationBuilder.DropIndex(
                name: "IX_GuideDetails_UserGuid",
                table: "GuideDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPermissions",
                table: "UserPermissions");

            migrationBuilder.DropColumn(
                name: "ShowCreatedByUser",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "UserGuid",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                table: "GuideDetails");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "GuideDetails");

            migrationBuilder.DropColumn(
                name: "OriginalGuideGuid",
                table: "GuideDetails");

            migrationBuilder.DropColumn(
                name: "ShowCreatedByUser",
                table: "GuideDetails");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "GuideDetails");

            migrationBuilder.DropColumn(
                name: "SubTitle",
                table: "GuideDetails");

            migrationBuilder.DropColumn(
                name: "TranslatorGuid",
                table: "GuideDetails");

            migrationBuilder.DropColumn(
                name: "UserGuid",
                table: "GuideDetails");

            migrationBuilder.DropColumn(
                name: "Views",
                table: "GuideDetails");

            migrationBuilder.RenameTable(
                name: "UserPermissions",
                newName: "UserPermission");

            migrationBuilder.AddColumn<string>(
                name: "ShortTitle",
                table: "GuideDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Translator",
                table: "GuideDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPermission",
                table: "UserPermission",
                columns: new[] { "UserGuid", "PermissionType" });

            migrationBuilder.CreateTable(
                name: "GuideMetas",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    ShowCreatedByUser = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    UserGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Views = table.Column<int>(type: "int", nullable: false)
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
                name: "Permission",
                columns: table => new
                {
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Type);
                });

            migrationBuilder.CreateTable(
                name: "GuideMetaGuideDetails",
                columns: table => new
                {
                    GuideMetaGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GuideDetailGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageType = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.InsertData(
                table: "Permission",
                column: "Type",
                values: new object[]
                {
                    0,
                    1,
                    2,
                    3,
                    4,
                    5,
                    6,
                    7,
                    8,
                    9,
                    10,
                    11
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserPermission_PermissionType",
                table: "UserPermission",
                column: "PermissionType");

            migrationBuilder.CreateIndex(
                name: "IX_GuideMetaGuideDetails_GuideDetailGuid",
                table: "GuideMetaGuideDetails",
                column: "GuideDetailGuid");

            migrationBuilder.CreateIndex(
                name: "IX_GuideMetas_UserGuid",
                table: "GuideMetas",
                column: "UserGuid");

            migrationBuilder.AddForeignKey(
                name: "ForeignKey_UserPermissions_Permissions",
                table: "UserPermission",
                column: "PermissionType",
                principalTable: "Permission",
                principalColumn: "Type",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
