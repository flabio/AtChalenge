namespace AtChalenge.Core.Entities;

public partial class Comment
{
    public int IdComment { get; set; }

    public string Descrption { get; set; } = null!;

    public int IdMovie { get; set; }

    public bool IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Movie IdMovieNavigation { get; set; } = null!;
}
