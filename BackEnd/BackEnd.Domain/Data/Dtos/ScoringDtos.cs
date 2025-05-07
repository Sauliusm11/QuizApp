using FluentValidation;

namespace BackEnd.Domain.Data.Dtos
{
    public record ScoreDto(int Id, DateTime DateTime,int Points, string Email);

    public record CreateScoreDto(string[] Answers, string Email);
}
