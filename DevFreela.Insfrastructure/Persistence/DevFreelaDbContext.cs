using DevFreela.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Insfrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            Projects = new List<Project>{
            new Project("Meu projeto 1", "minha drescrição 1", 1, 1, 1000),
            new Project("Meu projeto 2", "minha drescrição 2", 1, 1, 1000),
            new Project("Meu projeto 3", "minha drescrição 3", 1, 1, 1000)
        };
        }
       
        public List<Project> Projects { get; private set; }
        public List<User> Users { get; private set; }
        public List<Skill> Skills { get; private set; }
        public List<ProjectComment> ProjectComment  { get; private set; }
    }
}
