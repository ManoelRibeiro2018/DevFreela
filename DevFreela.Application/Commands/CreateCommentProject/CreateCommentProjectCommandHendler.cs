using DevFreela.Application.InputModel;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Core.Entites;
using DevFreela.Insfrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.CreateCommentProject
{
    public class CreateCommentProjectCommandHendler : IRequestHandler<CreateCommentProjectCommand, Unit>
    {
        private readonly DevFreelaDbContext _dbContext;

        public CreateCommentProjectCommandHendler(DevFreelaDbContext devFreelaDbContext)
        {
            _dbContext = devFreelaDbContext;
        }

        public async Task<Unit> Handle(CreateCommentProjectCommand request, CancellationToken cancellationToken)
        {
            var comment = new ProjectComment(request.Content, request.IdProject, request.IdUser);
            await _dbContext.ProjectComment.AddAsync(comment);
            await _dbContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
