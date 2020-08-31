using System.Data;
using AssistantHytale.Domain.Mapper;

namespace AssistantHytale.Domain.Contract
{
    public class Pagination
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalRows { get; set; }

        public static Pagination FromDataRow(DataRow row)
        {
            return new Pagination
            {
                CurrentPage = row.ReadInt("CurrentPage"),
                TotalPages = row.ReadInt("TotalPages"),
                TotalRows = row.ReadInt("TotalRows"),
            };
        }
    }
}
