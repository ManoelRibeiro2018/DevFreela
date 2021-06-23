using DevFreela.API.Models;
using DevFreela.Application.Commands.CreateCommentProject;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.InputModel;
using DevFreela.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public readonly IMediator _mediator;

        public ProjectsController(IProjectService projectService, IMediator mediator)
        {
            _projectService = projectService;
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var projects = _projectService.GetAll();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var project = _projectService.GetById(id);
            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand  command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(
                nameof(GetById),
                new { id },
                command
                );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectCommand command)
        {
            if (id <= 0)
            {
                return BadRequest(); 
            }

           await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _mediator.Send(id);
            return NoContent();
        }

        [HttpPost("{id}/comments")]
        public async Task<IActionResult> PostComment(int id, [FromBody] CreateCommentProjectCommand command)
        {
            await  _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("id/start")]
        public IActionResult Start(int id)
        {
            _projectService.Start(id);
            return NoContent();
        }


        [HttpPut("id/finish")]
        public IActionResult Finish(int id)
        {
            _projectService.Finish(id);
            return NoContent();
        }
    }

}
