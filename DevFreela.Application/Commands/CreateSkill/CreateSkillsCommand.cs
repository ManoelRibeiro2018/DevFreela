using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.CreateSkill
{
    public class CreateSkillsCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Description { get;  set; }

    }
}
