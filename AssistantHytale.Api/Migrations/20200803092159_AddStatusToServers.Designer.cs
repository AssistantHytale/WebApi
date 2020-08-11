﻿// <auto-generated />
using System;
using AssistantHytale.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AssistantHytale.Api.Migrations
{
    [DbContext(typeof(HytaleAssistantContext))]
    [Migration("20200803092159_AddStatusToServers")]
    partial class AddStatusToServers
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AssistantHytale.Persistence.Entity.Contributor", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Contribution")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SortRank")
                        .HasColumnType("int");

                    b.HasKey("Guid");

                    b.ToTable("Contributors");
                });

            modelBuilder.Entity("AssistantHytale.Persistence.Entity.Permission", b =>
                {
                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Type");

                    b.ToTable("Permission");

                    b.HasData(
                        new
                        {
                            Type = 0
                        },
                        new
                        {
                            Type = 1
                        },
                        new
                        {
                            Type = 2
                        },
                        new
                        {
                            Type = 3
                        },
                        new
                        {
                            Type = 4
                        },
                        new
                        {
                            Type = 5
                        },
                        new
                        {
                            Type = 6
                        },
                        new
                        {
                            Type = 7
                        },
                        new
                        {
                            Type = 8
                        },
                        new
                        {
                            Type = 9
                        },
                        new
                        {
                            Type = 10
                        },
                        new
                        {
                            Type = 11
                        });
                });

            modelBuilder.Entity("AssistantHytale.Persistence.Entity.Server", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("ApprovalStatus")
                        .HasColumnType("int");

                    b.Property<string>("Banner")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cloudflare")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<DateTime>("CreatDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<string>("Discord")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Facebook")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reddit")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Tags")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Twitter")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Guid");

                    b.ToTable("Servers");
                });

            modelBuilder.Entity("AssistantHytale.Persistence.Entity.Setting", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ActiveDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Guid");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("AssistantHytale.Persistence.Entity.User", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EmailHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("JoinDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OAuthType")
                        .HasColumnType("int");

                    b.Property<string>("OAuthUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Guid");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AssistantHytale.Persistence.Entity.UserPermission", b =>
                {
                    b.Property<Guid>("UserGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PermissionType")
                        .HasColumnType("int");

                    b.HasKey("UserGuid", "PermissionType");

                    b.HasIndex("PermissionType");

                    b.ToTable("UserPermission");
                });

            modelBuilder.Entity("AssistantHytale.Persistence.Entity.UserPermission", b =>
                {
                    b.HasOne("AssistantHytale.Persistence.Entity.Permission", "Permission")
                        .WithMany("UserPermissions")
                        .HasForeignKey("PermissionType")
                        .HasConstraintName("ForeignKey_UserPermissions_Permissions")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AssistantHytale.Persistence.Entity.User", "User")
                        .WithMany("Permissions")
                        .HasForeignKey("UserGuid")
                        .HasConstraintName("ForeignKey_UserPermissions_Users")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}