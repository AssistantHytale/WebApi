using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AssistantHytale.Domain.Dto.Enum;
using Microsoft.EntityFrameworkCore;

namespace AssistantHytale.Persistence.Entity
{
    public class GuideMeta
    {
        [Required]
        public Guid Guid { get; set; }

        [Required]
        public int Likes { get; set; }

        [Required]
        public int Views { get; set; }

        [Required]
        public bool ShowCreatedByUser { get; set; }

        [Required]
        public Guid UserGuid { get; set; }

        [Required]
        public AdminApprovalStatus Status { get; set; }

        
        #region Relationships

        public virtual User User { get; set; }
        public virtual ICollection<GuideMetaGuideDetail> GuideMetaGuideDetails { get; set; }

        public static void MapRelationships(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GuideMeta>().HasKey(p => p.Guid);
            modelBuilder.Entity<GuideMeta>().Property(g => g.Status).HasDefaultValue(AdminApprovalStatus.Pending);
            modelBuilder.Entity<GuideMeta>()
                .HasOne(up => up.User)
                .WithMany(b => b.GuideMetas)
                .HasForeignKey(up => up.UserGuid)
                .HasConstraintName("ForeignKey_User_GuideMetas");
        }
        #endregion
    }
}
