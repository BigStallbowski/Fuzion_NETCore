using Fuzion.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fuzion.Core.ModelConfigurations
{
    public class OSConfiguration : IEntityTypeConfiguration<OS> 
    {
        public void Configure(EntityTypeBuilder<OS> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Name)
                .HasMaxLength(55)
                .IsRequired();
        }
    }
}