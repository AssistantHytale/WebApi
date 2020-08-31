using System;
using System.Collections.Generic;
using AssistantHytale.Domain.Dto.Enum;

namespace AssistantHytale.Domain.Dto.ViewModel.Guide
{
    public class GuideDetailViewModel
    {
        public Guid Guid { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public int Likes { get; set; }
        public int Views { get; set; }
        public bool ShowCreatedByUser { get; set; }
        public Guid UserGuid { get; set; }
        public string LanguageCode { get; set; }
        public int Minutes { get; set; }
        public List<string> Tags { get; set; }
        public Guid OriginalGuideGuid { get; set; }
        public Guid? TranslatorGuid { get; set; }
        public AdminApprovalStatus Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
