using AtChalenge.Core.Entities;

namespace AtChalenge.Core.Interfaces
{
    public interface IMovieService
    {
        Task<bool> CreateMovie(Movie movie);
        Task<bool> DeleteMovie(int id);
        Task<Movie> GetMovie(int id);
        Task<IEnumerable<Movie>> GetMovies(int idGender);
        Task<IEnumerable<IMovieQueryDto>> GetMoviesComment();
        Task<bool> UpdateMovie(int id, Movie movie);
    }
}