using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using AssistantHytale.Domain.Dto.Enum;
using Microsoft.EntityFrameworkCore;

namespace AssistantHytale.Persistence.Entity
{
    public class GuideDetail
    {
        [Required]
        public Guid Guid { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string SubTitle { get; set; }

        [Required]
        public int Likes { get; set; }

        [Required]
        public int Views { get; set; }

        [Required]
        public bool ShowCreatedByUser { get; set; }

        [Required]
        public Guid UserGuid { get; set; }

        [Required]
        public string LanguageCode { get; set; }

        [Required]
        public int Minutes { get; set; }

        [Required]
        public string Tags { get; set; }

        [Required]
        public Guid OriginalGuideGuid { get; set; }

        [Required]
        public Guid TranslatorGuid { get; set; }

        [Required]
        public AdminApprovalStatus Status { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime DateUpdated { get; set; }

        #region Relationships

        public virtual User User { get; set; }
        public virtual ICollection<GuideContent> GuideContents { get; set; }

        public static void MapRelationships(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GuideDetail>().HasKey(p => p.Guid);
            modelBuilder.Entity<GuideDetail>().Property(g => g.Status).HasDefaultValue(AdminApprovalStatus.Pending);
            modelBuilder.Entity<GuideDetail>()
                .HasOne(up => up.User)
                .WithMany(b => b.GuideDetails)
                .HasForeignKey(up => up.UserGuid)
                .HasConstraintName("ForeignKey_User_GuideDetails")
                .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<GuideDetail>()
            //    .HasOne(up => up.Translator)
            //    .WithMany(b => b.GuideDetails)
            //    .HasForeignKey(up => up.TranslatorGuid)
            //    .HasConstraintName("ForeignKey_Translator_GuideDetails")
            //    .OnDelete(DeleteBehavior.Restrict);
        }
        #endregion
    }
}
