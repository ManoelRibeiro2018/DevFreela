using Dapper;
using DevFreela.Application.InputModel;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModel;
using DevFreela.Core.Entites;
using DevFreela.Insfrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly DevFreelaDbContext _dbContext;
        private readonly string _connectionString;
        public ProjectService(DevFreelaDbContext devFreelaDbContext, IConfiguration configuration)
        {
            _dbContext = devFreelaDbContext;
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        }
        public int Create(ProjectInputModel inputModel)
        {
            var project = new Project(inputModel.Title, inputModel.Description, inputModel.IdClient, inputModel.IdFreelancer, inputModel.TotalCost);
            _dbContext.Projects.Add(project);
            _dbContext.SaveChanges();
            return project.Id;
        }
        public void CreateComment(CommentInputModel inputModel)
        {
            var comment = new ProjectComment(inputModel.Content, inputModel.IdProject, inputModel.IdUser);
            _dbContext.ProjectComment.Add(comment);
            _dbContext.SaveChanges();
        }
        public void Update(UpdateProjectInputModel inputModel)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == inputModel.Id); 
            if (project != null)
            {
                project.Update(inputModel.Title, inputModel.Description, inputModel.TotalCost);
                _dbContext.SaveChanges();
            }

        }
        public void Delete(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

            if (project != null)
            {
                project.Cancel();
                _dbContext.SaveChanges();
            }
        }

        public List<ProjectViewModel> GetAll()
        {
            using (var sqlconnection = new SqlConnection(_connectionString))
            {
                sqlconnection.Open();
                var script = "Select Id, Title, CreatedAd from Project";
                return sqlconnection.Query<ProjectViewModel>(script).ToList();
            }


            //var projects = _dbContext.Projects.Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt)).ToList();
            //return projects;
        }

        public ProjectDetailsViewModel GetById(int id)
        {
            var project = _dbContext.Projects
                .Include(p => p.Client)
                .Include(p =>  p.Freelancer)
                .SingleOrDefault(p => p.Id == id);
            if (project == null)
            {
                return null;
            }

            var projectView = new ProjectDetailsViewModel(
                project.Id,
                project.Title,
                project.Description,
                project.TotalCost,
                project.StartedAt,
                project.Client.FullName,
                project.Freelancer.FullName
                ) ;
            return projectView;
        }

        public void Start(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

            if (project != null)
            {
                using(var sqlConection = new SqlConnection(_connectionString))
                {
                    sqlConection.Open();
                    var script = "UPDATE Projects SET Status = @status, Started = @startedAt WHERE Id = @id";
                    sqlConection.Execute(script, new { status = project.Status, startedAt = project.StartedAt, id });
                }

                //project.Start();
                //_dbContext.SaveChanges();
            }
        }


        public void Finish(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

            if (project != null)
            {
                project.Finish();
                _dbContext.SaveChanges();
            }
        }


    }
}
