using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.CreateSkill
{
    public class CreateSkillsCommand : IRequest<int>
    {
        public string Description { get; private set; }
        public int IdUSer { get; set; }

    }
}
