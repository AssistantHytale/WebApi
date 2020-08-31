using System;
using System.Collections.Generic;

namespace AssistantHytale.Domain.Dto.ViewModel.Guide
{
    public class AddGuideDetailViewModel
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public bool ShowCreatedByUser { get; set; }
        public string LanguageCode { get; set; }
        public int Minutes { get; set; }
        public List<string> Tags { get; set; }
    }
}
