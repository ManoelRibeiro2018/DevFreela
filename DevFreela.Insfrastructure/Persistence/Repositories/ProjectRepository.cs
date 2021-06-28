using DevFreela.Core.Entites;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Insfrastructure.Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DevFreelaDbContext _dbContext;
        public ProjectRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Project project)
        {
            throw new NotImplementedException();
        }

        public async Task AddCommentAsync(ProjectComment projectComment)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Project>> GetAllAsync()
        {
            return await _dbContext.Projects.ToListAsync();
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Project> GetDetailsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task StartAsync(Project project)
        {
            throw new NotImplementedException();
        }
    }


}
