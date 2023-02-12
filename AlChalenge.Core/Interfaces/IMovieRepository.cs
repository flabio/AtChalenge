using AtChalenge.Core.Entities;

namespace AtChalenge.Core.Interfaces
{
    public interface IMovieRepository
    {
        Task<bool> CreateMovie(Movie Movie);
        Task<bool> DeleteMovie(int id);
        Task<Movie> GetMovie(int id);
        Task<IEnumerable<Movie>> GetMovies(int idGender);
        Task<IEnumerable<IMovieQueryDto>> GetMoviesComment();
        Task<bool> UpdateMovie(int id, Movie movie);
    }
}