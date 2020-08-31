using System.IO;

namespace AssistantHytale.Persistence.Helper
{
    public class SqlFileHelper
    {
        public static string GetSqlFileContentFromStoredProceduresFolder(string filename)
        {
            string projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
#if DEBUG
            projectDir = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "AssistantHytale.Persistence");
#endif
            string persistenceStoredProcDir = Path.Combine(projectDir, "StoredProcedures");
            string sqlFile = Path.Combine(persistenceStoredProcDir, filename);
            return File.ReadAllText(sqlFile);
        }
    }
}
