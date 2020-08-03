using System;
using System.Collections.Generic;

namespace AssistantHytale.Domain.Dto.ViewModel.Guide
{
    public class GuideDetailViewModel
    {
        public Guid Guid { get; set; }
        public string Title { get; set; }
        public string ShortTitle { get; set; }
        public string Author { get; set; }
        public string Translator { get; set; }
        public int Minutes { get; set; }
        public List<string> Tags { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
