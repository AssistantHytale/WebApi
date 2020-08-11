using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AssistantHytale.Api.Migrations
{
    public partial class AddStatusToServers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Servers",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    ShortDescription = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: false),
                    Picture = table.Column<string>(nullable: false),
                    Banner = table.Column<string>(nullable: false),
                    Address = table.Column<string>(maxLength: 50, nullable: false),
                    Tags = table.Column<string>(nullable: false),
                    Cloudflare = table.Column<string>(maxLength: 10, nullable: false),
                    Region = table.Column<string>(maxLength: 50, nullable: false),
                    Language = table.Column<string>(maxLength: 25, nullable: false),
                    Version = table.Column<string>(maxLength: 50, nullable: false),
                    Website = table.Column<string>(maxLength: 50, nullable: false),
                    Discord = table.Column<string>(maxLength: 50, nullable: false),
                    Reddit = table.Column<string>(maxLength: 50, nullable: false),
                    Facebook = table.Column<string>(maxLength: 50, nullable: false),
                    Twitter = table.Column<string>(maxLength: 50, nullable: false),
                    ApprovalStatus = table.Column<int>(nullable: false),
                    CreatDateTime = table.Column<DateTime>(nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servers", x => x.Guid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Servers");
        }
    }
}
