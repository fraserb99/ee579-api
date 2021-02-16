using System;
using System.Collections.Generic;
using System.Text;
using EE579.Domain.Entities;
using EE579.Domain.Entities.Inputs;
using EE579.Domain.Entities.Output;
using Microsoft.EntityFrameworkCore;

namespace EE579.Domain
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> opts) :
            base(opts) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer("Data Source=.;Initial Catalog=EE579;Integrated Security=SSPI");
            }
        }

        public virtual DbSet<Tenant> Tenants { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<Rule> Rules { get; set; }
        public virtual DbSet<RuleInput> RuleInputs { get; set; }
        public virtual DbSet<RuleOutput> RuleOutputs { get; set; }
        public virtual DbSet<DeviceGroup> DeviceGroups { get; set; }

        public virtual DbSet<ButtonPushedInput> ButtonPushedInputs { get; set; }
        public virtual DbSet<SwitchInput> SwitchInputs { get; set; }
        public virtual DbSet<PotentiometerInput> PotInputs { get; set; }
        public virtual DbSet<TemperatureInput> TempInputs { get; set; }
        public virtual DbSet<PowerOnInput> PowerInputs { get; set; }

        public virtual DbSet<BuzzerBeepOutput> BuzzerBeepOutputs { get; set; }
        public virtual DbSet<BuzzerOnOutput> BuzzerOnOutputs { get; set; }
        public virtual DbSet<LedBlinkOutput> LedBlinkOutputs { get; set; }
        public virtual DbSet<LedBreatheOutput> LedBreatheOutputs { get; set; }
        public virtual DbSet<LedCycleOutput> LedCycleOutputs { get; set; }
        public virtual DbSet<LedFadeOutput> LedFadeOutputs { get; set; }
        public virtual DbSet<LedOutput> LedOutputs { get; set; }
    }
}
