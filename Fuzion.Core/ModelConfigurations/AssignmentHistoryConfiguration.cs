using Fuzion.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fuzion.Core.ModelConfigurations
{
    public class AssignmentHistoryConfiguration : IEntityTypeConfiguration<AssignmentHistory>
    {
        public void Configure(EntityTypeBuilder<AssignmentHistory> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Body)
                .HasMaxLength(1055)
                .IsRequired();
        }
    }
}