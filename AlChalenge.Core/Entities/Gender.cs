namespace AtChalenge.Core.Entities;

public partial class Gender
{
    public int IdGender { get; set; }

    public string Name { get; set; } = null!;

    public bool? IsActive { get; set; }

    public virtual ICollection<Movie> Movies { get; } = new List<Movie>();
}
