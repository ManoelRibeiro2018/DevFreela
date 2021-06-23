using DevFreela.API.Models;
using DevFreela.Application.Commands.CreateUser;
using DevFreela.Application.InputModel;
using DevFreela.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/users")]
    public class UsersController: ControllerBase
    {
        private readonly IUserService _userService;

        public IMediator _mediator;

        public UsersController(IUserService userService, IMediator mediator)
        {
            _userService = userService;
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] CreateUserCommand  command)
        {
            var id = _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id}, command);
        }

        [HttpPut("{id}/login")]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            return Ok();
        }
    }

}
