using Fuzion.UI.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fuzion.UI.Core.ModelConfigurations
{
    public class OSConfiguration : IEntityTypeConfiguration<OS>
    {
        public void Configure(EntityTypeBuilder<OS> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Name)
                .HasMaxLength(55)
                .IsRequired();

            builder.HasIndex(o => o.Name)
                .IsUnique();
        }
    }
}