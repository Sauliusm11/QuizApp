using BackEnd.Data.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Domain.Data.Dtos.Validators
{
    public class CreateScoreDtoValidator : AbstractValidator<CreateScoreDto>
    {
        public CreateScoreDtoValidator()
        {
            RuleFor(dto => dto.Email).NotEmpty().NotNull().EmailAddress().Length(min: 2, max: 255);
            RuleFor(dto => dto.answers).NotEmpty().NotNull();
        }
    }
}
