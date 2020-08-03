using System;
using System.ComponentModel.DataAnnotations;
using AssistantHytale.Domain.Dto.Enum;
using Microsoft.EntityFrameworkCore;

namespace AssistantHytale.Persistence.Entity
{
    public class Server
    {
        [Required]
        public Guid Guid { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(100)]
        public string ShortDescription { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public string Picture { get; set; }

        [Required]
        public string Banner { get; set; }

        [Required]
        [MaxLength(50)]
        public string Address { get; set; }

        [Required]
        public string Tags { get; set; }

        [Required]
        [MaxLength(10)]
        public string Cloudflare { get; set; }

        [Required]
        [MaxLength(50)]
        public string Region { get; set; }

        [Required]
        [MaxLength(25)]
        public string Language { get; set; }

        [Required]
        [MaxLength(50)]
        public string Version { get; set; }

        [Required]
        [MaxLength(50)]
        public string Website { get; set; }

        [Required]
        [MaxLength(50)]
        public string Discord { get; set; }

        [Required]
        [MaxLength(50)]
        public string Reddit { get; set; }

        [Required]
        [MaxLength(50)]
        public string Facebook { get; set; }

        [Required]
        [MaxLength(50)]
        public string Twitter { get; set; }

        [Required]
        public ServerApprovalStatus ApprovalStatus { get; set; }
        
        [Required]
        public DateTime CreateDateTime { get; set; }

        [Required]
        public DateTime UpdatedDateTime { get; set; }


        #region Relationships

        public static void MapRelationships(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Server>().HasKey(p => p.Guid);
        }
        #endregion
    }
}
