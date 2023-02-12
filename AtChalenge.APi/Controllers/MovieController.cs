using AtChalenge.Core.DTOs;
using AtChalenge.Core.Entities;
using AtChalenge.Core.Extensions;
using AtChalenge.Core.Interfaces;
using AtChalenge.Infrastructure.Responses;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AtChalenge.APi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public MovieController(IMovieService movieService, IMapper mapper, IWebHostEnvironment env)
        {
            _movieService = movieService;
            _mapper = mapper;
            _env = env;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int idGender)
        {
            try
            {
                var movies = await _movieService.GetMovies(idGender);
                var results = _mapper.Map<IEnumerable<MovieDto>>(movies);
                return StatusCode(StatusCodes.Status200OK, new ResponseModel()
                {
                    IsSuccessfull = true,
                    Data = results
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel() { Message = ex.Message });
            }

        }

        [HttpGet, Route("movie_comment")]
        
        public async Task<IActionResult> GetMovieComment()
        {
            try
            {
                var movies = await _movieService.GetMoviesComment();
            
                return StatusCode(StatusCodes.Status200OK, new ResponseModel()
                {
                    IsSuccessfull = true,
                    Data = movies
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel() { Message = ex.Message });
            }

        }
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] MovieFileDto moviefileDto)
        {
            try
            {
                bool resultado = false;
                var file = Request.Form.Files[0];
                string NombreCarpeta = "/Archivos/";
                string RutaRaiz = _env.ContentRootPath;
                string RutaCompleta = RutaRaiz + NombreCarpeta;

                if (!Directory.Exists(RutaCompleta))
                {
                    Directory.CreateDirectory(RutaCompleta);
                }

                if (file.Length > 0)
                {
                    string NombreArchivo = file.FileName;
                    string RutaFullCompleta = Path.Combine(RutaCompleta, NombreArchivo);
                    using (var stream = new FileStream(RutaFullCompleta, FileMode.Create))
                    {
                        file.CopyTo(stream);
                        resultado = true;
                    }
                    if (resultado) {
                        var movieDto = new MovieDto()
                        {
                            Name = moviefileDto.Name,
                            DatePublication = moviefileDto.DatePublication,
                            Description = moviefileDto.Description,
                            Duration = moviefileDto.Duration,
                            MovieYear = moviefileDto.MovieYear,
                            IdGender = moviefileDto.IdGender,
                            IsActive = moviefileDto.IsActive,
                            CreatedAt = moviefileDto.CreatedAt,
                            ImagenPath = RutaFullCompleta

                        };
                        var movie = _mapper.Map<Movie>(movieDto);
                        var result = await _movieService.CreateMovie(movie);
                        movieDto = _mapper.Map<MovieDto>(movie);

                        return StatusCode(StatusCodes.Status200OK, new ResponseModel()
                        {
                            IsSuccessfull = true,
                            Message = result ? MessagesAlert.SuccessfullyCreated : MessagesAlert.NotSuccessfullyCreated,
                            Data = movieDto
                        });
                    }

                }
             
                    return StatusCode(StatusCodes.Status200OK, new ResponseModel()
                    {
                        IsSuccessfull = false,
                        Message = "error file",
                        Data = moviefileDto
                    });
                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel() { Message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await _movieService.GetMovie(id);

                return StatusCode(StatusCodes.Status200OK, new ResponseModel()
                {
                    IsSuccessfull = true,
                    Message = null,
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel() { Message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, MovieDto movieDto)
        {
            try
            {
                var Movie = _mapper.Map<Movie>(movieDto);
                var result = await _movieService.UpdateMovie(id, Movie);
                movieDto = _mapper.Map<MovieDto>(Movie);

                return StatusCode(StatusCodes.Status200OK, new ResponseModel()
                {
                    IsSuccessfull = true,
                    Message = result ? MessagesAlert.SuccessfullyUpdated : MessagesAlert.NotSuccessfullyUpdated,
                    Data = movieDto
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel() { Message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Detele(int id)
        {
            try
            {
                var result = await _movieService.DeleteMovie(id);

                return StatusCode(StatusCodes.Status200OK, new ResponseModel()
                {
                    IsSuccessfull = true,
                    Message = result ? MessagesAlert.SuccessfullyRemoved : MessagesAlert.NotSuccessfullyDeleted,
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel() { Message = ex.Message });
            }
        }
       


            }
}