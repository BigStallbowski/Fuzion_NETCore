using Fuzion.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fuzion.Core.ModelConfigurations
{
    public class HardwareConfiguration : IEntityTypeConfiguration<Hardware>
    {
        public void Configure(EntityTypeBuilder<Hardware> builder)
        {
            builder.HasKey(h => h.Id);

            builder.Property(h => h.AssetNumber)
                .HasMaxLength(5)
                .IsRequired();

            builder.Property(h => h.SerialNumber)
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(h => h.IsAssigned)
                .HasDefaultValue(0);

            builder.Property(h => h.IsRetired)
                .HasDefaultValue(0);

            builder.Property(h => h.AssignedTo)
                .HasMaxLength(55);

            builder.Property(h => h.HardwareType)
                .IsRequired();

            builder.HasOne(h => h.HardwareType)
                .WithMany(h => h.Hardware);

            builder.Property(h => h.Manufacturer)
                .IsRequired();

            builder.HasOne(h => h.Manufacturer)
                .WithMany(m => m.Hardware);

            builder.Property(h => h.Model)
                .IsRequired();

            builder.HasOne(h => h.Model)
                .WithMany(m => m.Hardware);

            builder.HasOne(h => h.OS)
                .WithMany(o => o.Hardware);

            builder.HasOne(h => h.Purpose)
                .WithMany(p => p.Hardware);

            builder.HasMany(h => h.Notes)
                .WithOne(n => n.Hardware);

            builder.HasMany(h => h.AssignmentHistory)
                .WithOne(a => a.Hardware);
        }
    }
}