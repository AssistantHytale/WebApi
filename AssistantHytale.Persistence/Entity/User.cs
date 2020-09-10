using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace AssistantHytale.Persistence.Entity
{
    public class User
    {
        [Required]
        public Guid Guid { get; set; }

        [Required]
        public string AssistantAppsGuid { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }


        #region Relationships
        public virtual ICollection<UserPermission> Permissions { get; set; }
        public virtual ICollection<Server> Servers { get; set; }

        public static void MapRelationships(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(p => p.Guid);
        }
        #endregion
    }
}
