namespace AtChalenge.Core.Entities;

public partial class Movie
{
    public int IdMovie { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Duration { get; set; } = null!;

    public string MovieYear { get; set; } = null!;

    public DateTime DatePublication { get; set; }

    public int IdGender { get; set; }

    public bool IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? ImagenPath { get; set; }

    public virtual ICollection<Comment> Comments { get; } = new List<Comment>();

    public virtual Gender IdGenderNavigation { get; set; } = null!;
}
