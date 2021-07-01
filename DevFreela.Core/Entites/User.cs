using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Entites
{
    public class User : BaseEntity
    {
        public User(string fullName, string email, DateTime birthDate, string password, string role)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            CreateAt = DateTime.Now;
            Active = true;
            Password = password;
            Role = role;
            UserSkills = new List<UserSkill>();
            OwnerProjects = new List<Project>();
            FreelanceProjects = new  List<Project>();
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public DateTime CreateAt { get; private set; }
        public bool Active { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public List<UserSkill> UserSkills { get; private set; }
        public List<Project> OwnerProjects { get; private set; }
        public List<Project> FreelanceProjects { get; private set; }
        public List<ProjectComment>  ProjectComments { get; set; }

        public void Update(string fullName, DateTime birthDate)
        {
            FullName = fullName;
            BirthDate = birthDate;
        }

        public void Deactivate()
        {
            Active = false;
        }
    }
}
