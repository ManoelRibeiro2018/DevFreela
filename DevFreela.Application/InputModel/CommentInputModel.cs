using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.InputModel
{
    public class CommentInputModel
    {
        public CommentInputModel(int id, string content, int idProject, int idUser)
        {
            Id = id;
            Content = content;
            IdProject = idProject;
            IdUser = idUser;
        }

        public int Id { get; set; }
        public string Content { get; set; }
        public int IdProject { get; set; }
        public int IdUser { get; set; }
    }
}
