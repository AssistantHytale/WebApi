using AssistantHytale.Persistence.Helper;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AssistantHytale.Api.Migrations
{
    public partial class AddGetActiveGuideStoredProc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string guideSchemaSql = SqlFileHelper.GetSqlFileContentFromStoredProceduresFolder("01 - CreateGuideSchema.sql");
            migrationBuilder.Sql(guideSchemaSql);
            string sql = SqlFileHelper.GetSqlFileContentFromStoredProceduresFolder("02 - GetActiveGuidesPaged.sql");
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
