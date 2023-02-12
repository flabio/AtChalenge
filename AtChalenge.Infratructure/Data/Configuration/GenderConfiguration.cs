using AtChalenge.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtChalenge.Infrastructure.Data.Configuration
{
    public class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.HasKey(e => e.IdGender);

            builder.ToTable("Gender");

            builder.Property(e => e.Name).HasMaxLength(250);
        }
    }
}
