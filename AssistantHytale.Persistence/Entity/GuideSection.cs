using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace AssistantHytale.Persistence.Entity
{
    public class GuideSection
    {
        [Required]
        public Guid Guid { get; set; }

        [Required]
        public Guid GuideContentGuid { get; set; }

        [Required]
        public string Heading { get; set; }

        [Required]
        public int SortOrder { get; set; }

        #region Relationships

        public virtual GuideContent GuideContent { get; set; }
        public virtual ICollection<GuideSectionItem> Items { get; set; }

        public static void MapRelationships(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GuideSection>().HasKey(p => p.Guid);
            modelBuilder.Entity<GuideSection>()
                .HasOne(up => up.GuideContent)
                .WithMany(b => b.Sections)
                .HasForeignKey(up => up.GuideContentGuid)
                .HasConstraintName("ForeignKey_Section_GuideContent")
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
        #endregion
    }
}
