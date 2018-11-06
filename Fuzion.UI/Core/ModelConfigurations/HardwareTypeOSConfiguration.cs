using Fuzion.UI.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fuzion.UI.Core.ModelConfigurations
{
    public class HardwareTypeOSConfiguration : IEntityTypeConfiguration<HardwareTypeOS>
    {
        public void Configure(EntityTypeBuilder<HardwareTypeOS> builder)
        {
            builder.HasKey(k => new {k.HardwareTypeId, k.OSId});

            builder.HasOne(ht => ht.HardwareType)
                .WithMany(t => t.OperatingSystems)
                .HasForeignKey(ht => ht.HardwareTypeId);

            builder.HasOne(ht => ht.OS)
                .WithMany(ht => ht.HardwareTypes)
                .HasForeignKey(o => o.OSId);
        }
    }
}