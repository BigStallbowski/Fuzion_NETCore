using Fuzion.Core.ModelConfigurations;
using Fuzion.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Fuzion.Core.Context
{
    public class FuzionDbContext : DbContext
    {
        public FuzionDbContext(DbContextOptions<FuzionDbContext> options) : base(options) { }

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
    }
}