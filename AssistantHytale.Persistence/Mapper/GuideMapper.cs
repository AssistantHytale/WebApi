using System;
using System.Collections.Generic;
using System.Linq;
using AssistantHytale.Domain.Dto.ViewModel.Guide;
using AssistantHytale.Persistence.Entity;

namespace AssistantHytale.Persistence.Mapper
{
    public static class GuideMapper
    {
        public static GuideMetaViewModel ToDto(this GuideMeta guideMeta)
        {
            GuideMetaViewModel vm = new GuideMetaViewModel
            {
                Guid = guideMeta.Guid,
                UserGuid = guideMeta.UserGuid,
                Likes = guideMeta.Likes,
                Views = guideMeta.Views,
                ShowCreatedByUser = guideMeta.ShowCreatedByUser
            };

            return vm;
        }
        public static List<GuideMetaViewModel> ToDto(this List<GuideMeta> orig) => orig.Select(o => o.ToDto()).ToList();


        public static GuideMeta ToPersistence(this AddGuideMetaViewModel vm)
        {
            GuideMeta persistence = new GuideMeta
            {
                Guid = Guid.NewGuid(),
                UserGuid = vm.UserGuid,
                Likes = 0,
                Views = 0,
                ShowCreatedByUser = vm.ShowCreatedByUser
            };

            return persistence;
        }

        public static GuideDetailViewModel ToDto(this GuideDetail persistence)
        {
            GuideDetailViewModel vm = new GuideDetailViewModel
            {
                Guid = persistence.Guid,
                Title = persistence.Title,
                ShortTitle = persistence.ShortTitle,
                Minutes = persistence.Minutes,
                Tags = persistence.Tags.Split(",").ToList(),
                Author = string.Empty,
                Translator = persistence.Translator,
                DateCreated = persistence.DateCreated,
                DateUpdated = persistence.DateUpdated,
            };

            return vm;
        }
        public static List<GuideDetailViewModel> ToDto(this List<GuideDetail> orig) => orig.Select(o => o.ToDto()).ToList();
    }
}
