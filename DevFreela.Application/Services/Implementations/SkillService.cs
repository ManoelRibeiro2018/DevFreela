using DevFreela.Application.InputModel;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Insfrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Implementations
{
    public class Skillservice : ISkillService
    {
        private readonly DevFreelaDbContext _dbcontext;

        public Skillservice(DevFreelaDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public List<SkillViewModel> GetAll()
        {
            var skills =  _dbcontext.Skills.Select(s => new SkillViewModel(s.Id, s.Description)).ToList();
            return skills;

        }
    }
}
