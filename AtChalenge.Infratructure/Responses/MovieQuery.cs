using AtChalenge.Core.Interfaces;

namespace AtChalenge.Infrastructure.Responses
{
    public class MovieQuery:IMovieQueryDto
    {
        public int IdMovie { get; set; }

        public string Name { get; set; }
        public int IdComment { get; set; }
        public string? ImagenPath { get; set; }
    }
}
