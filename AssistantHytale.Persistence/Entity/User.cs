using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AssistantHytale.Domain.Dto.Enum;
using Microsoft.EntityFrameworkCore;

namespace AssistantHytale.Persistence.Entity
{
    public class User
    {
        [Required]
        public Guid Guid { get; set; }

        [Required]
        public string ProfileImageUrl { get; set; }

        [Required]
        [MaxLength(100)]
        public string Username { get; set; }

        [Required]
        public string EmailHash { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        public OAuthProviderType OAuthType { get; set; }

        [Required]
        public string OAuthUserId { get; set; }

        [Required]
        public DateTime JoinDate { get; set; }


        #region Relationships
        public virtual ICollection<GuideDetail> GuideDetails { get; set; }
        public virtual ICollection<UserPermission> Permissions { get; set; }
        public virtual ICollection<Server> Servers { get; set; }

        public static void MapRelationships(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(p => p.Guid);
        }
        #endregion
    }
}
