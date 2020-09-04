using System;
using System.Collections.Generic;
using System.Data;
using AssistantHytale.Domain.Dto.Enum;
using AssistantHytale.Domain.Mapper;
using Newtonsoft.Json;

namespace AssistantHytale.Persistence.Contract
{
    public class GuideFullContent
    {
        public Guid Guid { get; set; }
        public Guid GuideDetailGuid { get; set; }
        public AdminApprovalStatus Status { get; set; }
        public int Version { get; set; }
        public DateTime DateCreated { get; set; }
        public List<GuideFullContentSection> Sections { get; set; }


        public static GuideFullContent FromDataTable(DataRow row, DataTable sectionTable, List<DataTable> sectionItemTables)
        {
            List<GuideFullContentSection> sections = new List<GuideFullContentSection>();
            for (int sectionRowIndex = 0; sectionRowIndex < sectionTable.Rows.Count; sectionRowIndex++)
            {
                DataRow sectionRow = sectionTable.Rows[sectionRowIndex];
                GuideFullContentSection section = GuideFullContentSection.FromDataTable(sectionRow, sectionItemTables[sectionRowIndex].Rows);
                sections.Add(section);
            }

            return new GuideFullContent
            {
                GuideDetailGuid = row.ReadGuid("GuideDetailGuid"),
                Status = row.ReadEnum<AdminApprovalStatus>("Status"),
                Version = row.ReadInt("Version"),
                DateCreated = row.ReadDateTime("DateCreated"),
                Sections = sections
            };
        }
    }

    public class GuideFullContentSection
    {
        public Guid Guid { get; set; }
        public Guid GuideContentGuid { get; set; }
        public string Heading { get; set; }
        public List<GuideFullContentSectionItem> Items { get; set; }

        public static GuideFullContentSection FromDataTable(DataRow row, DataRowCollection itemRows)
        {
            List<GuideFullContentSectionItem> items = new List<GuideFullContentSectionItem>();
            foreach (DataRow itemRow in itemRows)
            {
                items.Add(GuideFullContentSectionItem.FromDataTable(itemRow));
            }
            
            return new GuideFullContentSection
            {
                Guid = row.ReadGuid("Guid"),
                GuideContentGuid = row.ReadGuid("GuideContentGuid"),
                Heading = row.ReadString("Heading"),
                Items = items,
            };
        }
    }

    public class GuideFullContentSectionItem
    {
        public Guid Guid { get; set; }
        public Guid GuideSectionGuid { get; set; }
        public GuideSectionItemType Type { get; set; }
        public string Content { get; set; }
        public string AdditionalContent { get; set; }
        public List<string> TableColumnNames { get; set; }
        public List<List<string>> TableData { get; set; }

        public static GuideFullContentSectionItem FromDataTable(DataRow row)
        {
            return new GuideFullContentSectionItem
            {
                Guid = row.ReadGuid("Guid"),
                GuideSectionGuid = row.ReadGuid("GuideSectionGuid"),
                Type = row.ReadEnum<GuideSectionItemType>("Type"),
                Content = row.ReadString("Content"),
                AdditionalContent = row.ReadString("AdditionalContent"),
                TableColumnNames = JsonConvert.DeserializeObject<List<string>>(row.ReadString("TableColumnNames")),
                TableData = JsonConvert.DeserializeObject<List<List<string>>>(row.ReadString("TableData")),
            };
        }
    }
}
