using AtChalenge.Core.Entities;
using AtChalenge.Infrastructure.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace AtChalenge.Infrastructure.Data;

public partial class AtChalengeContext : DbContext
{
    public AtChalengeContext()
    {
    }

    public AtChalengeContext(DbContextOptions<AtChalengeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CommentConfiguration());

        modelBuilder.ApplyConfiguration(new GenderConfiguration());

        modelBuilder.ApplyConfiguration(new MovieConfiguration());

    
    }

}
