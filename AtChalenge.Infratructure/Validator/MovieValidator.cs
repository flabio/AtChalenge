using AtChalenge.Core.DTOs;
using FluentValidation;

namespace AtChalenge.Infrastructure.Validator
{
    public class MovieValidator:AbstractValidator<MovieDto>
    {
        public MovieValidator()
        {
            RuleFor(movie => movie.Name)
                .NotEmpty()
                .NotNull()
                .Length(4, 250)
                .WithMessage("the name is required."); 
            RuleFor(movie => movie.Description)
                .NotEmpty()
                .NotNull()
                .WithMessage("the description is required"); 
            RuleFor(movie => movie.Duration)
                .NotEmpty()
                .NotNull()
                .WithMessage("the duration is required");
            RuleFor(movie => movie.MovieYear)
                .NotEmpty()
                .NotNull()
                .WithMessage("the year of the movie is required"); 
            RuleFor(movie => movie.DatePublication)
                .NotEmpty()
                .NotNull()
                .LessThan(DateTime.Now)
                .WithMessage("the publication date is required");
            RuleFor(movie => movie.IdGender)
                .NotEmpty()
                .NotNull()
                .WithMessage("the gender is required");
        }
    }
}
