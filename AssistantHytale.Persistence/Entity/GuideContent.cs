using System;
using System.ComponentModel.DataAnnotations;
using AssistantHytale.Domain.Dto.Enum;
using Microsoft.EntityFrameworkCore;

namespace AssistantHytale.Persistence.Entity
{
    public class GuideContent
    {
        [Required]
        public Guid Guid { get; set; }

        [Required]
        public AdminApprovalStatus Status { get; set; }

        [Required]
        public int Version { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        #region Relationships

        public virtual GuideDetail GuideDetail { get; set; }

        public static void MapRelationships(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GuideContent>().HasKey(p => p.Guid);
            modelBuilder.Entity<GuideContent>()
                .HasOne(up => up.GuideDetail)
                .WithMany(b => b.GuideContents)
                .HasForeignKey(up => up.Guid)
                .HasConstraintName("ForeignKey_Content_GuideDetails");
        }
        #endregion
    }
}
