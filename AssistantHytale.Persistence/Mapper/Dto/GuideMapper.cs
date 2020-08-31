using System.Collections.Generic;
using System.Linq;
using AssistantHytale.Domain.Dto.ViewModel.Guide;
using AssistantHytale.Persistence.Entity;

namespace AssistantHytale.Persistence.Mapper.Dto
{
    public static class GuideMapper
    {
        public static GuideDetailViewModel ToDto(this GuideDetail persistence)
        {
            GuideDetailViewModel vm = new GuideDetailViewModel
            {
                Guid = persistence.Guid,
                Title = persistence.Title,
                SubTitle = persistence.SubTitle,
                Likes = persistence.Likes,
                Views = persistence.Views,
                ShowCreatedByUser = persistence.ShowCreatedByUser,
                UserGuid = persistence.UserGuid,
                LanguageCode = persistence.LanguageCode,
                Minutes = persistence.Minutes,
                Tags = persistence.Tags.Split(",").ToList(),
                OriginalGuideGuid = persistence.OriginalGuideGuid,
                TranslatorGuid = persistence.TranslatorGuid,
                Status = persistence.Status,
                DateCreated = persistence.DateCreated,
                DateUpdated = persistence.DateUpdated,
            };

            return vm;
        }
    }
}
