using AtChalenge.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtChalenge.Infrastructure.Data.Configuration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(e => e.IdComment);

            builder.ToTable("Comment");

            builder.Property(e => e.CreatedAt)
                .HasColumnType("smalldatetime")
                .HasColumnName("Created_at");
            builder.Property(e => e.Descrption).HasColumnType("text");

            builder.HasOne(d => d.IdMovieNavigation).WithMany(p => p.Comments)
                .HasForeignKey(d => d.IdMovie)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comment_Movie");
        }
    }
}
