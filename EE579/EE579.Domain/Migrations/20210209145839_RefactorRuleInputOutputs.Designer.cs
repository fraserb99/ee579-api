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
    [Migration("20210209145839_RefactorRuleInputOutputs")]
    partial class RefactorRuleInputOutputs
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("Device");
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

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.HasIndex("RuleId");

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

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.HasIndex("RuleId");

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

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("EE579.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RefreshToken")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TenantUser", b =>
                {
                    b.Property<Guid>("TenantsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TenantsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("TenantUser");
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
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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

                    b.Navigation("Device");
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

                    b.Navigation("Device");
                });

            modelBuilder.Entity("EE579.Domain.Entities.Tenant", b =>
                {
                    b.HasOne("EE579.Domain.Entities.User", "Owner")
                        .WithMany("OwnedTenants")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("TenantUser", b =>
                {
                    b.HasOne("EE579.Domain.Entities.Tenant", null)
                        .WithMany()
                        .HasForeignKey("TenantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EE579.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
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
                });

            modelBuilder.Entity("EE579.Domain.Entities.User", b =>
                {
                    b.Navigation("OwnedTenants");
                });
#pragma warning restore 612, 618
        }
    }
}
