using Fuzion.UI.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fuzion.UI.Core.ModelConfigurations
{
    public class ModelConfiguration : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Name)
                .HasMaxLength(55)
                .IsRequired();

            builder.HasIndex(m => m.Name)
                .IsUnique();

            builder.HasOne(model => model.Manufacturer)
                .WithMany(manufacturer => manufacturer.Models)
                .HasForeignKey(model => model.ManufacturerId)
                .IsRequired();
        }
    }
}