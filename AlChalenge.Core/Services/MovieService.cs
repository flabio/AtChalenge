using AtChalenge.Core.Entities;
using AtChalenge.Core.Interfaces;

namespace AtChalenge.Core.Services
{
    public class MovieService :IMovieService
    {
        private readonly IMovieRepository _MovieRepository;
   
        public MovieService(IMovieRepository MovieRepository)
        {
            _MovieRepository = MovieRepository;
         
        }

        public async Task<Movie> GetMovie(int id)
        {
            return await _MovieRepository.GetMovie(id);
        }

        public async Task<IEnumerable<Movie>> GetMovies(int idGender)
        {
            return await _MovieRepository.GetMovies(idGender);
        }
        public async Task<IEnumerable<IMovieQueryDto>> GetMoviesComment()
        {
            return await _MovieRepository.GetMoviesComment();
        }


        public async Task<bool> CreateMovie(Movie movie)
        {
           return await _MovieRepository.CreateMovie(movie);
        }

        public async Task<bool> UpdateMovie(int id, Movie movie)
        {
            return await _MovieRepository.UpdateMovie(id, movie);
        }
        public async Task<bool> DeleteMovie(int id)
        {
            return await _MovieRepository.DeleteMovie(id);
        }

        #region
        //method private


        #endregion
    }
}
