using Fuzion.UI.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fuzion.UI.Core.ModelConfigurations
{
    public class HardwareTypeConfiguration : IEntityTypeConfiguration<HardwareType>
    {
        public void Configure(EntityTypeBuilder<HardwareType> builder)
        {
            builder.HasKey(h => h.Id);

            builder.Property(h => h.Name)
                .HasMaxLength(25)
                .IsRequired();

            builder.HasIndex(x => x.Name).IsUnique();
        }
    }
}