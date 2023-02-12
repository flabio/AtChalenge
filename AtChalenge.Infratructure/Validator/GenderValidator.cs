using AtChalenge.Core.DTOs;
using FluentValidation;

namespace AtChalenge.Infrastructure.Validator
{
    public class GenderValidator:AbstractValidator<GenderDto>
    {
        public GenderValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("the name is required");
        }
    }
}
