using DevFreela.API.Models;
using DevFreela.Application.Commands.CreateUser;
using DevFreela.Application.InputModel;
using DevFreela.Application.Querys.GetUser;
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

        public IMediator _mediator;

        public UsersController( IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetUserByIdQuery(id);
            var user = await _mediator.Send(query);
            return Ok(user);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand  command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id}, command);
        }

        [HttpPut("{id}/login")]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            return Ok();
        }
    }

}
