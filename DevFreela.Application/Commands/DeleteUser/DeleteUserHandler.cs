using DevFreela.Insfrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.DeleteUser
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly DevFreelaDbContext _dbContext;
        public DeleteUserHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == request.Id);

            if (user != null)
            {
              user.Deactivate();
              await  _dbContext.SaveChangesAsync();
            }
            return Unit.Value;
        }
    }
}
