using System;

namespace AssistantHytale.Domain.Dto.ViewModel.Guide
{
    public class AddGuideMetaViewModel
    {
        public Guid UserGuid { get; set; }
        public bool ShowCreatedByUser { get; set; }
    }
}
