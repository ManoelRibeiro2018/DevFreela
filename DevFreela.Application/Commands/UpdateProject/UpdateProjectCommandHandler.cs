using DevFreela.Insfrastructure.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.UpdateProject
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Unit>
    {
        private readonly DevFreelaDbContext _dbContext;
        public UpdateProjectCommandHandler(DevFreelaDbContext devFreelaDbContext)
        {
            _dbContext = devFreelaDbContext;
        }
        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == request.Id);
            if (project != null)
            {
                project.Update(request.Title, request.Description, request.TotalCost);
                await _dbContext.SaveChangesAsync();
            }
            return Unit.Value;
        }
    }
}
