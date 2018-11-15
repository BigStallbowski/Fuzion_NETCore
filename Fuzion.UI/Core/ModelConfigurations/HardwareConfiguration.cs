using Fuzion.UI.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fuzion.UI.Core.ModelConfigurations
{
    public class HardwareConfiguration : IEntityTypeConfiguration<Hardware>
    {
        public void Configure(EntityTypeBuilder<Hardware> builder)
        {
            builder.HasKey(h => h.Id);

            builder.Property(h => h.AssetNumber)
                .HasMaxLength(5)
                .IsRequired();

            builder.HasIndex(h => h.AssetNumber)
                .IsUnique();

            builder.Property(h => h.SerialNumber)
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(h => h.IsAssigned)
                .HasDefaultValue(0);

            builder.Property(h => h.IsRetired)
                .HasDefaultValue(0);

            builder.Property(h => h.AssignedTo)
                .HasMaxLength(55);

            builder.HasOne(h => h.HardwareType)
                .WithMany(ht => ht.Hardware)
                .HasForeignKey(h => h.HardwareTypeId)
                .IsRequired();

            builder.HasOne(h => h.Manufacturer)
                .WithMany(m => m.Hardware)
                .HasForeignKey(h => h.ManufacturerId)
                .IsRequired();

            builder.HasOne(h => h.Model)
                .WithMany(m => m.Hardware)
                .HasForeignKey(h => h.ModelId)
                .IsRequired();

            builder.HasOne(h => h.OS)
                .WithMany(o => o.Hardware)
                .HasForeignKey(h => h.OSId);

            builder.HasOne(h => h.Purpose)
                .WithMany(p => p.Hardware)
                .HasForeignKey(h => h.PurposeId);

            builder.HasMany(h => h.Notes)
                .WithOne(n => n.Hardware);

            builder.HasMany(h => h.AssignmentHistory)
                .WithOne(a => a.Hardware);
        }
    }
}