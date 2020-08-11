using System;
using AssistantHytale.Domain.Dto.Enum;

namespace AssistantHytale.Domain.Dto.ViewModel.Server
{
    public class ServerViewModel
    {
        public Guid Guid { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public string Banner { get; set; }
        public string Address { get; set; }
        public string Tags { get; set; }
        public string Cloudflare { get; set; }
        public string Region { get; set; }
        public string Language { get; set; }
        public string Version { get; set; }
        public string Website { get; set; }
        public string Discord { get; set; }
        public string Reddit { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public AdminApprovalStatus ApprovalStatus { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }
}
