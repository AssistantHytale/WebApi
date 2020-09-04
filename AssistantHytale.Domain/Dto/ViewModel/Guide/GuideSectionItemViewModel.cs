using System;
using System.Collections.Generic;
using AssistantHytale.Domain.Dto.Enum;

namespace AssistantHytale.Domain.Dto.ViewModel.Guide
{
    public class GuideSectionItemViewModel
    {
        public Guid Guid { get; set; }
        public GuideSectionItemType Type { get; set; }
        public string Content { get; set; }
        public string AdditionalContent { get; set; }
        public List<string> TableColumnNames { get; set; }
        public List<List<string>> TableData { get; set; }
    }
}
