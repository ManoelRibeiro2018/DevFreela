using DevFreela.Application.ViewModel;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand,LoginUserViewModel>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;
        public LoginUserCommandHandler(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }

        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            //Utiliza o mesmo algoritimo para criar um hash dessa senha
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            //Consulta o usuario pelo email e senha hasheado
            var user = await _userRepository.GetUserByEmailAndPasswordAsync(request.Email, passwordHash);

            //Tratamento
            if (user == null)
            {
                return null;
            }

            //se existir, gerar o token com as informações do usuário
            var token = _authService.GenerateJwtToken(user.Email, user.Role);

            return new LoginUserViewModel(user.Email, token);
        }
    }
}
