using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AssistantHytale.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contributors",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Link = table.Column<string>(nullable: false),
                    Contribution = table.Column<string>(nullable: false),
                    SortRank = table.Column<int>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contributors", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Type);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: false),
                    ActiveDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    ProfileImageUrl = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: false),
                    EmailHash = table.Column<string>(nullable: false),
                    OAuthType = table.Column<int>(nullable: false),
                    OAuthUserId = table.Column<string>(nullable: false),
                    JoinDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "UserPermission",
                columns: table => new
                {
                    UserGuid = table.Column<Guid>(nullable: false),
                    PermissionType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermission", x => new { x.UserGuid, x.PermissionType });
                    table.ForeignKey(
                        name: "ForeignKey_UserPermissions_Permissions",
                        column: x => x.PermissionType,
                        principalTable: "Permission",
                        principalColumn: "Type",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "ForeignKey_UserPermissions_Users",
                        column: x => x.UserGuid,
                        principalTable: "Users",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contributors");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "UserPermission");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
