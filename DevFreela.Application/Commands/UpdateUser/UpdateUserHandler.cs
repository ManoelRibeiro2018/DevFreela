using DevFreela.Insfrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly DevFreelaDbContext _dbContext;
        public UpdateUserHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == request.Id);

            if (user != null)
            {
                user.Update(request.FullName, request.BirthDate);
             await   _dbContext.SaveChangesAsync();
            }
            return Unit.Value;
        }
    }
}
