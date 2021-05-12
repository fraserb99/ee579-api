using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EE579.Domain.Entities;
using EE579.Domain.Entities.Inputs;
using EE579.Domain.Entities.Output;
using EE579.Domain.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EE579.Domain
{
    public class DatabaseContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        private readonly HttpContext _httpContext;

        public DatabaseContext(DbContextOptions<DatabaseContext> opts, IHttpContextAccessor contextAccessor) 
            : base(opts)
        {
            _httpContext = contextAccessor.HttpContext;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer("Data Source=.;Initial Catalog=EE579;Integrated Security=SSPI");
            }
        }

        public virtual DbSet<Tenant> Tenants { get; set; }
        public virtual DbSet<TenantUser> TenantUsers { get; set; }
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<Rule> Rules { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<RuleInput> RuleInputs { get; set; }
        public virtual DbSet<RuleOutput> RuleOutputs { get; set; }
        public virtual DbSet<DeviceGroup> DeviceGroups { get; set; }

        public virtual DbSet<ButtonPushedInput> ButtonPushedInputs { get; set; }
        public virtual DbSet<SwitchInput> SwitchInputs { get; set; }
        public virtual DbSet<PotentiometerInput> PotInputs { get; set; }
        public virtual DbSet<TemperatureInput> TempInputs { get; set; }
        public virtual DbSet<PowerOnInput> PowerInputs { get; set; }
        public virtual DbSet<WebhookInput> WebhookInputs { get; set; }

        public virtual DbSet<BuzzerBeepOutput> BuzzerBeepOutputs { get; set; }
        public virtual DbSet<BuzzerOffOutput> BuzzerOffOutputs { get; set; }
        public virtual DbSet<BuzzerOnOutput> BuzzerOnOutputs { get; set; }
        public virtual DbSet<LedBlinkOutput> LedBlinkOutputs { get; set; }
        public virtual DbSet<LedBreatheOutput> LedBreatheOutputs { get; set; }
        public virtual DbSet<LedCycleOutput> LedCycleOutputs { get; set; }
        public virtual DbSet<LedFadeOutput> LedFadeOutputs { get; set; }
        public virtual DbSet<LedOutput> LedOutputs { get; set; }
        public virtual DbSet<WebhookOutput> WebhookOutputs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Tenant>()
                .HasMany(p => p.Users)
                .WithMany(p => p.Tenants)
                .UsingEntity<TenantUser>(
                    j => j
                        .HasOne(tu => tu.User)
                        .WithMany(u => u.TenantUsers)
                        .HasForeignKey(tu => tu.UserId),
                    j => j
                        .HasOne(tu => tu.Tenant)
                        .WithMany(t => t.TenantUsers)
                        .HasForeignKey(tu => tu.TenantId),
                    j =>
                    {
                        j.HasKey(t => new { t.TenantId, t.UserId });
                    });

            modelBuilder.Entity<TenantUser>()
                .HasQueryFilter(x =>
                    !_httpContext.GetTenantId().HasValue ||
                    x.TenantId == _httpContext.GetTenantId());

            modelBuilder.Entity<Device>()
                .HasQueryFilter(x =>
                    !_httpContext.GetTenantId().HasValue ||
                    x.TenantId == _httpContext.GetTenantId());

            modelBuilder.Entity<Rule>()
                .HasQueryFilter(x =>
                    !_httpContext.GetTenantId().HasValue ||
                    x.TenantId == _httpContext.GetTenantId());

            modelBuilder.Entity<DeviceGroup>()
                .HasQueryFilter(x =>
                    !_httpContext.GetTenantId().HasValue ||
                    x.TenantId == _httpContext.GetTenantId());

            modelBuilder.Entity<RuleInput>()
                .HasQueryFilter(x =>
                    !_httpContext.GetTenantId().HasValue ||
                    x.TenantId == _httpContext.GetTenantId());

            modelBuilder.Entity<RuleOutput>()
                .HasQueryFilter(x =>
                    !_httpContext.GetTenantId().HasValue || 
                    x.TenantId == _httpContext.GetTenantId());
            modelBuilder.Entity<Event>()
                .HasQueryFilter(x =>
                    !_httpContext.GetTenantId().HasValue ||
                    x.TenantId == _httpContext.GetTenantId());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return SaveChangesAsync(false, cancellationToken);
        }

        public new Task<int> SaveChangesAsync(bool disableTenantId = false,
            CancellationToken cancellationToken = new CancellationToken())
        {
            var tenantId = _httpContext.GetTenantId();
            if (disableTenantId || !tenantId.HasValue)
                return base.SaveChangesAsync(cancellationToken);

            foreach (var entity in ChangeTracker.Entries().Where(e => e.State == EntityState.Added))
            {
                var tenantIdProp = entity.Properties.FirstOrDefault(x => x.Metadata.Name == "TenantId");
                if (tenantIdProp != null)
                    tenantIdProp.CurrentValue = tenantId;
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
