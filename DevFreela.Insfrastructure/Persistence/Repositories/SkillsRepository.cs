using Dapper;
using DevFreela.Core.DTOs;
using DevFreela.Core.Entites;
using DevFreela.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Insfrastructure.Persistence.Repositories
{
    public class SkillsRepository : ISkillRepository
    {
        private readonly string _connection;
        public SkillsRepository(IConfiguration configuration)
        {

            _connection = configuration.GetConnectionString("DevFreellaCs");
        }

        public async Task CreateAsync(SkillDTO skill)
        {
            using (var sqlConnection = new SqlConnection(_connection))
            {
                sqlConnection.Open();
                string query = "INSERT INTO SKILLS (Description, CreatedAt) VALUES (@Description, @CreatedAt)";
                await sqlConnection.ExecuteAsync(query, new { skill.Description, skill.CreatedAt });

                sqlConnection.Close();
            }
        }

        public async Task<List<SkillDTO>> GetAllAsync()
        {

            using (var sqlConnection = new SqlConnection(_connection))
            {
                sqlConnection.Open();
                string query = "SELECT Id, Description FROM SKILLS ";
                var skills = await sqlConnection.QueryAsync<SkillDTO>(query);
                return skills.ToList();

            }
        }
    }
}
