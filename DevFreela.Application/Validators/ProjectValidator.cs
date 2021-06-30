using DevFreela.Application.Commands.CreateProject;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Validators
{
    public class ProjectValidator : AbstractValidator<CreateProjectCommand>
    {
        public ProjectValidator()
        {
            RuleFor(p => p.Title)
               .NotEmpty()
               .WithMessage("Informe o titulo do projeto");

            RuleFor(p => p.IdClient)
                .NotEmpty()
                .NotNull()
                .WithMessage("Informe o responsável pelo projeto");

            RuleFor(p => p.IdFreelancer)
               .NotEmpty()
               .NotNull()
               .WithMessage("Informe quem vai trabalhar no projeto");

            RuleFor(p => p.TotalCost)
                .Must(ValidatorTotalCost)
               .WithMessage("valo total inválido");
        }

        private bool ValidatorTotalCost(decimal value)
        {
            return value > 0; 
        }
    }
}
