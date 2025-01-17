using BackEnd.Data.Entities;
using FluentValidation;

namespace BackEnd.Data.Dtos
{
    public record ScoreDto(int id, DateTime DateTime,int points, string Email);

    public record CreateScoreDto(string[] answers, string Email);

    public class CreateScoreDtoValidator : AbstractValidator<CreateScoreDto>
    {
        public CreateScoreDtoValidator()
        {
            RuleFor(dto => dto.Email).NotEmpty().NotNull().EmailAddress().Length(min: 2, max: 255);
            RuleFor(dto => dto.answers).NotEmpty().NotNull();
        }
    }

}
