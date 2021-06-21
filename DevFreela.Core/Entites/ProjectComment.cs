]using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Entites
{
    public  class ProjectComment : BaseEntity
    {
        public ProjectComment(string content, int idProject, int idCliente)
        {
            Content = content;
            IdProject = idProject;
            IdCliente = idCliente;
            CreatedAt = DateTime.Now;
        }

        public string Content { get; private set; }
        public int IdProject { get; private set; }
        public int IdCliente { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
