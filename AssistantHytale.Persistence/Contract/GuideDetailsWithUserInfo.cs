using System.Data;
using AssistantHytale.Domain.Dto.Enum;
using AssistantHytale.Domain.Mapper;
using AssistantHytale.Persistence.Entity;

namespace AssistantHytale.Persistence.Contract
{
    public class GuideDetailsWithUserInfo: GuideDetail
    {
        public string UserName { get; set; }
        public string TranslatorName { get; set; }

        public static GuideDetailsWithUserInfo FromDataRow(DataRow row)
        {
            return new GuideDetailsWithUserInfo
            {
                Guid = row.ReadGuid("Guid"),
                Title = row.ReadString("Title"),
                Minutes = row.ReadInt("Minutes"),
                Tags = row.ReadString("Tags"),
                DateCreated = row.ReadDateTime("DateCreated"),
                DateUpdated = row.ReadDateTime("DateUpdated"),
                LanguageCode = row.ReadString("LanguageCode"),
                Likes = row.ReadInt("Likes"),
                Views = row.ReadInt("Views"),
                OriginalGuideGuid = row.ReadGuid("OriginalGuideGuid"),
                ShowCreatedByUser = row.ReadBool("ShowCreatedByUser"),
                Status = row.ReadEnum<AdminApprovalStatus>("Status"),
                SubTitle = row.ReadString("SubTitle"),
                TranslatorGuid = row.ReadGuid("TranslatorGuid"),
                UserGuid = row.ReadGuid("UserGuid"),
                // New fields
                UserName = row.ReadString("UserName"),
                TranslatorName = row.ReadString("TranslatorName"),
            };
        }
    }
}
