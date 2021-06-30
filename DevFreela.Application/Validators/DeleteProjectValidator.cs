using DevFreela.Application.Commands.DeleteProject;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Validators
{
    public class DeleteProjectValidator : AbstractValidator<DeleteProjectCommand>
    {
        public DeleteProjectValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("Informe o projeto");
        }
    }
}
