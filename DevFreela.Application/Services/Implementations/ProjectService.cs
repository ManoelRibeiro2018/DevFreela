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
            _connectionString = configuration.GetConnectionString("DevFreellaCs");
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
