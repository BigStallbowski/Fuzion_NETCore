using Fuzion.UI.Core.ModelConfigurations;
using Fuzion.UI.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Fuzion.UI.Core.Context
{
    public class FuzionDbContext : DbContext
    {
        public FuzionDbContext(DbContextOptions<FuzionDbContext> options) : base(options)
        {
        }

        public DbSet<Hardware> Hardware { get; set; }
        public DbSet<HardwareType> HardwareTypes { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<OS> OS { get; set; }
        public DbSet<Purpose> Purposes { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<AssignmentHistory> AssignmentHistory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HardwareConfiguration());
            modelBuilder.ApplyConfiguration(new HardwareTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ManufacturerConfiguration());
            modelBuilder.ApplyConfiguration(new ModelConfiguration());
            modelBuilder.ApplyConfiguration(new OSConfiguration());
            modelBuilder.ApplyConfiguration(new PurposeConfiguration());
            modelBuilder.ApplyConfiguration(new NoteConfiguration());
            modelBuilder.ApplyConfiguration(new AssignmentHistoryConfiguration());
        }

        public override int SaveChanges()
        {
            AddAuditInfo();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            AddAuditInfo();
            var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            return result;
        }

        private void AddAuditInfo()
        {
            var entries = ChangeTracker.Entries().Where(x =>
                x.Entity is BaseModel
                && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((BaseModel)entry.Entity).CreatedOn = DateTime.UtcNow;
                    ((BaseModel)entry.Entity).CreatedBy = "Testing Account";
                }
                ((BaseModel)entry.Entity).LastModifiedOn = DateTime.UtcNow;
                ((BaseModel)entry.Entity).LastModifiedBy = "Testing Account";
            }
        }
    }
}