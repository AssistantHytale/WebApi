using System.Collections.Generic;

namespace AssistantHytale.Domain.Dto.ViewModel.Guide
{
    public class GuideSectionViewModel
    {
        public string Guid { get; set; }
        public string Heading { get; set; }
        public List<GuideSectionItemViewModel> Items { get; set; }
    }
}
