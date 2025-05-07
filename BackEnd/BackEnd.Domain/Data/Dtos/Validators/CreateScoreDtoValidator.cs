using FluentValidation;

namespace BackEnd.Domain.Data.Dtos.Validators
{
    public class CreateScoreDtoValidator : AbstractValidator<CreateScoreDto>
    {
        public CreateScoreDtoValidator()
        {
            RuleFor(dto => dto.Email).NotEmpty().NotNull().EmailAddress().Length(min: 2, max: 255);
            RuleFor(dto => dto.Answers).NotEmpty().NotNull();
        }
    }
}
