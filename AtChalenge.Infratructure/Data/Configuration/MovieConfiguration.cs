using AtChalenge.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtChalenge.Infrastructure.Data.Configuration
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(e => e.IdMovie);

            builder.ToTable("Movie");

            builder.Property(e => e.CreatedAt)
                .HasColumnType("smalldatetime")
                .HasColumnName("Created_at");
            builder.Property(e => e.DatePublication).HasColumnType("date");
            builder.Property(e => e.Description).HasColumnType("ntext");
            builder.Property(e => e.Duration).HasMaxLength(50);
            builder.Property(e => e.MovieYear).HasMaxLength(10);

            builder.HasOne(d => d.IdGenderNavigation).WithMany(p => p.Movies)
                .HasForeignKey(d => d.IdGender)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Movie_Gender");
        }
    }
}
