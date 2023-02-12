using AtChalenge.Core.DTOs;
using AtChalenge.Core.Entities;
using AutoMapper;

namespace AtChalenge.Infrastructure.Mappings
{
    public class AutomapperProfile:Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Comment, CommentDto>();
            CreateMap<CommentDto, Comment>();
            CreateMap<Gender,GenderDto>();
            CreateMap<GenderDto,Gender>();
            CreateMap<Movie, MovieDto>();
            CreateMap<MovieDto, Movie>();
        }
    }
}
