using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.StartProject
{
    public class StartCommandHandler : IRequestHandler<StartCommand, Unit>
    {
        public Task<Unit> Handle(StartCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
