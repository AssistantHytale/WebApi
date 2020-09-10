using AssistantHytale.Persistence.Helper;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AssistantHytale.Api.Migrations
{
    public partial class AddGetActiveGuideStoredProc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //string guideSchemaSql = SqlFileHelper.GetSqlFileContentFromStoredProceduresFolder("001 - CreateGuideSchema.sql");
            //migrationBuilder.Sql(guideSchemaSql);
            //string activeGuideSql = SqlFileHelper.GetSqlFileContentFromStoredProceduresFolder("002 - GetActiveGuidesPaged.sql");
            //migrationBuilder.Sql(activeGuideSql);
            //string sql = SqlFileHelper.GetSqlFileContentFromStoredProceduresFolder("003 - GetGuideContentsWithSectionsAndItems.sql");
            //migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
