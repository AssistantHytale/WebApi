using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AssistantHytale.Api.Migrations
{
    public partial class AddGuideSectionAndGuideSectionItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "ForeignKey_Content_GuideDetails",
                table: "GuideContents");

            migrationBuilder.AddColumn<Guid>(
                name: "GuideDetailGuid",
                table: "GuideContents",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "GuideSections",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    GuideContentGuid = table.Column<Guid>(nullable: false),
                    Heading = table.Column<string>(nullable: false),
                    SortOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuideSections", x => x.Guid);
                    table.ForeignKey(
                        name: "ForeignKey_Section_GuideContent",
                        column: x => x.GuideContentGuid,
                        principalTable: "GuideContents",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GuideSectionItems",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    GuideSectionGuid = table.Column<Guid>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    AdditionalContent = table.Column<string>(nullable: false),
                    TableColumnNames = table.Column<string>(nullable: false),
                    TableData = table.Column<string>(nullable: false),
                    SortOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuideSectionItems", x => x.Guid);
                    table.ForeignKey(
                        name: "ForeignKey_SectionItem_GuideContent",
                        column: x => x.GuideSectionGuid,
                        principalTable: "GuideSections",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GuideContents_GuideDetailGuid",
                table: "GuideContents",
                column: "GuideDetailGuid");

            migrationBuilder.CreateIndex(
                name: "IX_GuideSectionItems_GuideSectionGuid",
                table: "GuideSectionItems",
                column: "GuideSectionGuid");

            migrationBuilder.CreateIndex(
                name: "IX_GuideSections_GuideContentGuid",
                table: "GuideSections",
                column: "GuideContentGuid");

            migrationBuilder.AddForeignKey(
                name: "ForeignKey_Content_GuideDetails",
                table: "GuideContents",
                column: "GuideDetailGuid",
                principalTable: "GuideDetails",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "ForeignKey_Content_GuideDetails",
                table: "GuideContents");

            migrationBuilder.DropTable(
                name: "GuideSectionItems");

            migrationBuilder.DropTable(
                name: "GuideSections");

            migrationBuilder.DropIndex(
                name: "IX_GuideContents_GuideDetailGuid",
                table: "GuideContents");

            migrationBuilder.DropColumn(
                name: "GuideDetailGuid",
                table: "GuideContents");

            migrationBuilder.AddForeignKey(
                name: "ForeignKey_Content_GuideDetails",
                table: "GuideContents",
                column: "Guid",
                principalTable: "GuideDetails",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
