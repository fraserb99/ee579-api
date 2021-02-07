using System;
using System.Collections.Generic;
using System.Text;
using EE579.Domain.Entities;
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
        public virtual DbSet<Rule> Rules { get; set; }
        public virtual DbSet<RuleInput> RuleInputs { get; set; }
        public virtual DbSet<RuleOutput> RuleOutputs { get; set; }
        public virtual DbSet<DeviceGroup> DeviceGroups { get; set; }
    }
}
