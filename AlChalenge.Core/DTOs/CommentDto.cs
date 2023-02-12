namespace AtChalenge.Core.DTOs
{
    public class CommentDto
    {
        public int IdComment { get; set; }

        public string? Descrption { get; set; }

        public int IdMovie { get; set; }

        public bool IsActive { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
