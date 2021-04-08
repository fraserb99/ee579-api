﻿// <auto-generated />
using System;
using EE579.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EE579.Domain.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20210408151645_FixDeviceTenantFK")]
    partial class FixDeviceTenantFK
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("DeviceDeviceGroup", b =>
                {
                    b.Property<Guid>("DeviceGroupsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DevicesId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("DeviceGroupsId", "DevicesId");

                    b.HasIndex("DevicesId");

                    b.ToTable("DeviceDeviceGroup");
                });

            modelBuilder.Entity("EE579.Domain.Entities.Device", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("DeviceState")
                        .HasColumnType("int");

                    b.Property<string>("IpAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("EE579.Domain.Entities.DeviceGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("DeviceGroups");
                });

            modelBuilder.Entity("EE579.Domain.Entities.Rule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("Rules");
                });

            modelBuilder.Entity("EE579.Domain.Entities.RuleInput", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DeviceId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("RuleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.HasIndex("RuleId");

                    b.HasIndex("TenantId");

                    b.ToTable("RuleInputs");

                    b.HasDiscriminator<string>("Discriminator").HasValue("RuleInput");
                });

            modelBuilder.Entity("EE579.Domain.Entities.RuleOutput", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DeviceId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OutputType")
                        .HasColumnType("int");

                    b.Property<Guid?>("RuleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.HasIndex("RuleId");

                    b.HasIndex("TenantId");

                    b.ToTable("RuleOutputs");

                    b.HasDiscriminator<string>("Discriminator").HasValue("RuleOutput");
                });

            modelBuilder.Entity("EE579.Domain.Entities.Tenant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("EE579.Domain.Entities.TenantUser", b =>
                {
                    b.Property<Guid>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("TenantId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("TenantUsers");
                });

            modelBuilder.Entity("EE579.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<Guid>("RefreshToken")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("EE579.Domain.Entities.Inputs.ButtonPushedInput", b =>
                {
                    b.HasBaseType("EE579.Domain.Entities.RuleInput");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("ButtonPushedInput");
                });

            modelBuilder.Entity("EE579.Domain.Entities.Inputs.PotentiometerInput", b =>
                {
                    b.HasBaseType("EE579.Domain.Entities.RuleInput");

                    b.Property<int>("GreaterThan")
                        .HasColumnType("int")
                        .HasColumnName("PotentiometerInput_GreaterThan");

                    b.Property<int>("LessThan")
                        .HasColumnType("int")
                        .HasColumnName("PotentiometerInput_LessThan");

                    b.HasDiscriminator().HasValue("PotentiometerInput");
                });

            modelBuilder.Entity("EE579.Domain.Entities.Inputs.PowerOnInput", b =>
                {
                    b.HasBaseType("EE579.Domain.Entities.RuleInput");

                    b.HasDiscriminator().HasValue("PowerOnInput");
                });

            modelBuilder.Entity("EE579.Domain.Entities.Inputs.SwitchInput", b =>
                {
                    b.HasBaseType("EE579.Domain.Entities.RuleInput");

                    b.Property<int>("Peripheral")
                        .HasColumnType("int");

                    b.Property<bool>("Value")
                        .HasColumnType("bit");

                    b.HasDiscriminator().HasValue("SwitchInput");
                });

            modelBuilder.Entity("EE579.Domain.Entities.Inputs.TemperatureInput", b =>
                {
                    b.HasBaseType("EE579.Domain.Entities.RuleInput");

                    b.Property<int>("GreaterThan")
                        .HasColumnType("int");

                    b.Property<int>("LessThan")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("TemperatureInput");
                });

            modelBuilder.Entity("EE579.Domain.Entities.Output.BuzzerBeepOutput", b =>
                {
                    b.HasBaseType("EE579.Domain.Entities.RuleOutput");

                    b.Property<int>("OffDuration")
                        .HasColumnType("int");

                    b.Property<int>("OnDuration")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("BuzzerBeepOutput");
                });

            modelBuilder.Entity("EE579.Domain.Entities.Output.BuzzerOnOutput", b =>
                {
                    b.HasBaseType("EE579.Domain.Entities.RuleOutput");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("BuzzerOnOutput");
                });

            modelBuilder.Entity("EE579.Domain.Entities.Output.LedBlinkOutput", b =>
                {
                    b.HasBaseType("EE579.Domain.Entities.RuleOutput");

                    b.Property<int>("Colour")
                        .HasColumnType("int")
                        .HasColumnName("LedBlinkOutput_Colour");

                    b.Property<int>("Period")
                        .HasColumnType("int")
                        .HasColumnName("LedBlinkOutput_Period");

                    b.Property<int>("Peripheral")
                        .HasColumnType("int")
                        .HasColumnName("LedBlinkOutput_Peripheral");

                    b.HasDiscriminator().HasValue("LedBlinkOutput");
                });

            modelBuilder.Entity("EE579.Domain.Entities.Output.LedBreatheOutput", b =>
                {
                    b.HasBaseType("EE579.Domain.Entities.RuleOutput");

                    b.Property<int>("Colour")
                        .HasColumnType("int")
                        .HasColumnName("LedBreatheOutput_Colour");

                    b.Property<int>("Period")
                        .HasColumnType("int")
                        .HasColumnName("LedBreatheOutput_Period");

                    b.Property<int>("Peripheral")
                        .HasColumnType("int")
                        .HasColumnName("LedBreatheOutput_Peripheral");

                    b.HasDiscriminator().HasValue("LedBreatheOutput");
                });

            modelBuilder.Entity("EE579.Domain.Entities.Output.LedCycleOutput", b =>
                {
                    b.HasBaseType("EE579.Domain.Entities.RuleOutput");

                    b.Property<bool>("Direction")
                        .HasColumnType("bit");

                    b.Property<int>("Period")
                        .HasColumnType("int")
                        .HasColumnName("LedCycleOutput_Period");

                    b.HasDiscriminator().HasValue("LedCycleOutput");
                });

            modelBuilder.Entity("EE579.Domain.Entities.Output.LedFadeOutput", b =>
                {
                    b.HasBaseType("EE579.Domain.Entities.RuleOutput");

                    b.Property<int>("Colour")
                        .HasColumnType("int")
                        .HasColumnName("LedFadeOutput_Colour");

                    b.Property<int>("Period")
                        .HasColumnType("int");

                    b.Property<int>("Peripheral")
                        .HasColumnType("int")
                        .HasColumnName("LedFadeOutput_Peripheral");

                    b.HasDiscriminator().HasValue("LedFadeOutput");
                });

            modelBuilder.Entity("EE579.Domain.Entities.Output.LedOutput", b =>
                {
                    b.HasBaseType("EE579.Domain.Entities.RuleOutput");

                    b.Property<int>("Colour")
                        .HasColumnType("int");

                    b.Property<int>("Peripheral")
                        .HasColumnType("int");

                    b.Property<bool>("Value")
                        .HasColumnType("bit");

                    b.HasDiscriminator().HasValue("LedOutput");
                });

            modelBuilder.Entity("DeviceDeviceGroup", b =>
                {
                    b.HasOne("EE579.Domain.Entities.DeviceGroup", null)
                        .WithMany()
                        .HasForeignKey("DeviceGroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EE579.Domain.Entities.Device", null)
                        .WithMany()
                        .HasForeignKey("DevicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EE579.Domain.Entities.Device", b =>
                {
                    b.HasOne("EE579.Domain.Entities.Tenant", "Tenant")
                        .WithMany("Devices")
                        .HasForeignKey("TenantId");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("EE579.Domain.Entities.DeviceGroup", b =>
                {
                    b.HasOne("EE579.Domain.Entities.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("EE579.Domain.Entities.Rule", b =>
                {
                    b.HasOne("EE579.Domain.Entities.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("EE579.Domain.Entities.RuleInput", b =>
                {
                    b.HasOne("EE579.Domain.Entities.Device", "Device")
                        .WithMany("Inputs")
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EE579.Domain.Entities.Rule", null)
                        .WithMany("Inputs")
                        .HasForeignKey("RuleId");

                    b.HasOne("EE579.Domain.Entities.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId");

                    b.Navigation("Device");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("EE579.Domain.Entities.RuleOutput", b =>
                {
                    b.HasOne("EE579.Domain.Entities.Device", "Device")
                        .WithMany("Outputs")
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EE579.Domain.Entities.Rule", null)
                        .WithMany("Outputs")
                        .HasForeignKey("RuleId");

                    b.HasOne("EE579.Domain.Entities.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId");

                    b.Navigation("Device");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("EE579.Domain.Entities.TenantUser", b =>
                {
                    b.HasOne("EE579.Domain.Entities.Tenant", "Tenant")
                        .WithMany("TenantUsers")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EE579.Domain.Entities.User", "User")
                        .WithMany("TenantUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tenant");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("EE579.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("EE579.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EE579.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("EE579.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EE579.Domain.Entities.Device", b =>
                {
                    b.Navigation("Inputs");

                    b.Navigation("Outputs");
                });

            modelBuilder.Entity("EE579.Domain.Entities.Rule", b =>
                {
                    b.Navigation("Inputs");

                    b.Navigation("Outputs");
                });

            modelBuilder.Entity("EE579.Domain.Entities.Tenant", b =>
                {
                    b.Navigation("Devices");

                    b.Navigation("TenantUsers");
                });

            modelBuilder.Entity("EE579.Domain.Entities.User", b =>
                {
                    b.Navigation("TenantUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
