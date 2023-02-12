using AtChalenge.Core.DTOs;
using FluentValidation;

namespace AtChalenge.Infrastructure.Validator
{
    public class CommentValidator:AbstractValidator<CommentDto>
    {
        public CommentValidator()
        {
            RuleFor(comment => comment.Descrption)
                .NotEmpty()
                .NotNull()
                .WithMessage("the description is required.");
            RuleFor(comment => comment.IdMovie)
                .NotEmpty()
                .NotNull()
                .WithMessage("the movie is required.");
        }
    }
}
