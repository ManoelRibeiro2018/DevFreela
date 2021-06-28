using Dapper;
using DevFreela.Core.DTOs;
using DevFreela.Core.Repositories;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.CreateSkill
{
    public class CreateSkillCommandHandler : IRequestHandler<CreateSkillsCommand, Unit>
    {
        private readonly ISkillRepository  _skillRepository;

        public CreateSkillCommandHandler(ISkillRepository  skillRepository)
        {
            _skillRepository = skillRepository;
        }   
        public async Task<Unit> Handle(CreateSkillsCommand request, CancellationToken cancellationToken)
        {
            var skill = new SkillDTO(request.Id, request.Description);
            await _skillRepository.CreateAsync(skill);
            return Unit.Value;
        }
    }
}
