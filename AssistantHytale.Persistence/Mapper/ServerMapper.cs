using System.Collections.Generic;
using System.Linq;
using AssistantHytale.Domain.Dto.ViewModel.Server;
using AssistantHytale.Persistence.Entity;

namespace AssistantHytale.Persistence.Mapper
{
    public static class ServerMapper
    {
        public static ServerViewModel ToDto(this Server persistence)
        {
            ServerViewModel vm = new ServerViewModel
            {
                Guid = persistence.Guid,
                Title = persistence.Title,
                ShortDescription = persistence.ShortDescription,
                Description = persistence.Description,
                Picture = persistence.Picture,
                Banner = persistence.Banner,
                Address = persistence.Address,
                Tags = persistence.Tags,
                Cloudflare = persistence.Cloudflare,
                Region = persistence.Region,
                Language = persistence.Language,
                Version = persistence.Version,
                Website = persistence.Website,
                Discord = persistence.Discord,
                Reddit = persistence.Reddit,
                Facebook = persistence.Facebook,
                Twitter = persistence.Twitter,
                ApprovalStatus = persistence.ApprovalStatus,
                CreateDateTime = persistence.CreateDateTime,
                UpdatedDateTime = persistence.UpdatedDateTime,
            };
            return vm;
        }
        public static List<ServerViewModel> ToDto(this List<Server> orig) => orig.Select(o => o.ToDto()).ToList();
    }
}
