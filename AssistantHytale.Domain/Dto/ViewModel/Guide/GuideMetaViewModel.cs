using System;

namespace AssistantHytale.Domain.Dto.ViewModel.Guide
{
    public class GuideMetaViewModel
    {
        public Guid Guid { get; set; }
        public int Likes { get; set; }
        public int Views { get; set; }
        public bool ShowCreatedByUser { get; set; }
        public Guid UserGuid { get; set; }
    }
}
