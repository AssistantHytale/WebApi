using System;
using System.ComponentModel.DataAnnotations;
using AssistantHytale.Domain.Dto.Enum;
using Microsoft.EntityFrameworkCore;

namespace AssistantHytale.Persistence.Entity
{
    public class GuideSectionItem
    {
        [Required]
        public Guid Guid { get; set; }

        [Required]
        public Guid GuideSectionGuid { get; set; }

        [Required]
        public GuideSectionItemType Type { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string AdditionalContent { get; set; }

        [Required]
        public string TableColumnNames { get; set; }

        [Required]
        public string TableData { get; set; }

        [Required]
        public int SortOrder { get; set; }


        #region Relationships

        public virtual GuideSection GuideSection { get; set; }

        public static void MapRelationships(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GuideSectionItem>().HasKey(p => p.Guid);
            modelBuilder.Entity<GuideSectionItem>()
                .HasOne(up => up.GuideSection)
                .WithMany(b => b.Items)
                .HasForeignKey(up => up.GuideSectionGuid)
                .HasConstraintName("ForeignKey_SectionItem_GuideContent")
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
        #endregion
    }
}
