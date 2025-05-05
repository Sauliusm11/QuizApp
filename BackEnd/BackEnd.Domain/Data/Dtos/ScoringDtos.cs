using FluentValidation;

namespace BackEnd.Domain.Data.Dtos
{
    public record ScoreDto(int id, DateTime DateTime,int points, string Email);

    public record CreateScoreDto(string[] answers, string Email);
}
