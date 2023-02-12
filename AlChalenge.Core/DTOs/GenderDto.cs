namespace AtChalenge.Core.DTOs
{
    public class GenderDto
    {
        public int IdGender { get; set; }

        public string Name { get; set; } = null!;

        public bool? IsActive { get; set; }
    }
}
