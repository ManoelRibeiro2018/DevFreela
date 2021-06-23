using Dapper;
using DevFreela.Application.InputModel;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Insfrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Implementations
{
    public class SkillService : ISkillService
    {
        private readonly DevFreelaDbContext _dbcontext;
        private readonly string _connectionString;

        public SkillService(DevFreelaDbContext dbcontext, IConfiguration configuration)
        {
            _dbcontext = dbcontext;
            _connectionString = configuration.GetConnectionString("DevFreellaCs");
        }
        public List<SkillViewModel> GetAll()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                var script = "SELECT Id, Description FROM Skills";
                return sqlConnection.Query<SkillViewModel>(script).ToList(); 
            }


            //var skills =  _dbcontext.Skills.Select(s => new SkillViewModel(s.Id, s.Description)).ToList();
            //return skills;

        }
    }
}
