﻿using System;
using System.ComponentModel.DataAnnotations;
using AssistantHytale.Domain.Dto.Enum;
using Microsoft.EntityFrameworkCore;

namespace AssistantHytale.Persistence.Entity
{
    public class UserPermission
    {
        [Required]
        public Guid UserGuid { get; set; }

        [Required]
        public PermissionType PermissionType { get; set; }


        #region Relationships

        public virtual User User { get; set; }
        public virtual Permission Permission { get; set; }

        public static void MapRelationships(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserPermission>().HasKey(userPermission => new { userPermission.UserGuid, userPermission.PermissionType });

            modelBuilder.Entity<UserPermission>()
                .HasOne(up => up.User)
                .WithMany(b => b.Permissions)
                .HasForeignKey(up => up.UserGuid)
                .HasConstraintName("ForeignKey_UserPermissions_Users");
            modelBuilder.Entity<UserPermission>()
                .HasOne(up => up.Permission)
                .WithMany(c => c.UserPermissions)
                .HasForeignKey(bc => bc.PermissionType)
                .HasConstraintName("ForeignKey_UserPermissions_Permissions");
        }
        #endregion
    }
}