using AtChalenge.Core.Entities;
using AtChalenge.Core.Interfaces;
using AtChalenge.Infrastructure.Data;
using AtChalenge.Infrastructure.Responses;
using Microsoft.EntityFrameworkCore;

namespace AtChalenge.Infrastructure.Repositories
{
    public class MovieRepository :IMovieRepository
    {
        private readonly AtChalengeContext _context;
        public MovieRepository(AtChalengeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Movie>> GetMovies(int idGender)
        {
            try
            {
                var results = await _context.Movies.ToListAsync();
                if (idGender==0) {
                    return results;
                   }
                    return results.Where(x => x.IsActive == true && x.IdGender==idGender);
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<IMovieQueryDto>> GetMoviesComment()
        {
            try
            {
                var result = await (from c in _context.Comments
                                    join m in _context.Movies on c.IdMovie equals m.IdMovie
                                    orderby c.IdMovie
                                    group m by m.IdMovie into  newMovie 
                                    select new MovieQuery()
                                    {
                                        IdMovie=newMovie.Key,
                                        Name=newMovie.ToList().First().Name,
                                        ImagenPath=newMovie.ToList().First().ImagenPath,
                                       
                                    }).ToListAsync<IMovieQueryDto>();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> CreateMovie(Movie movie)
        {
            try
            {
                _context.Movies.Add(movie);
                var row = await _context.SaveChangesAsync();
                if (row > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Movie> GetMovie(int id)
        {
            try
            {
                var result = await _context.Movies.Where(x => x.IsActive == true).FirstOrDefaultAsync(x=>x.IdMovie==id);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> UpdateMovie(int id, Movie movie)
        {
            try
            {
                var currentMovie = await GetMovie(id);
                if (currentMovie != null)
                {
                    currentMovie.Name = movie.Name;
                    currentMovie.Description = movie.Description;
                    currentMovie.Duration = movie.Duration;
                    currentMovie.DatePublication = movie.DatePublication;
                    currentMovie.MovieYear = movie.MovieYear;
                    currentMovie.ImagenPath = movie.ImagenPath;

                    var row = await _context.SaveChangesAsync();
                    return row > 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteMovie(int id)
        {
            try
            {
                var currentMovie = await GetMovie(id);
                if (currentMovie != null)
                {
                    currentMovie.IsActive = false;
                    var row = await _context.SaveChangesAsync();
                    return row > 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}