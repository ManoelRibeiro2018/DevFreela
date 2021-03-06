using DevFreela.Application.Commands.CreateCommentProject;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.Queries.GetProjectById;
using DevFreela.Application.Querys.GetAllProjects;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    [Authorize]
    public class ProjectsController : ControllerBase
    {
        public readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> Get(string query)
        {
            var getAll = new GetAllProjectsQuery(query);
            var projects = await _mediator.Send(getAll);
            return Ok(projects);
        }



        [HttpGet("{id}")]
        [Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetProjectByIdQuery(id);

            var project = await _mediator.Send(query);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        [HttpPost]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
        {
                var id = await _mediator.Send(command);

                return CreatedAtAction(nameof(GetById), new {  id }, command);
        }

        // api/projects/2
        [HttpPut("{id}")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        // api/projects/3 DELETE
        [HttpDelete("{id}")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Delete(int id)
        {

            var command = new DeleteProjectCommand(id);
            await _mediator.Send(command);

            return NoContent();

        }

        // api/projects/1/comments POST
        [HttpPost("{id}/comments")]
        [Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> PostComment(int id, [FromBody] CreateCommentProjectCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        // api/projects/1/start
        [HttpPut("{id}/start")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Start(int id)
        {
            var command = new StartCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        // api/projects/1/finish
        [HttpPut("{id}/finish")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Finish(int id, [FromBody] FinishProjectCommand command)
        {
            command.Id = id;

           var result = await _mediator.Send(command);
            
            if (!result)
            {
                return BadRequest("O pagamento não pode ser processado.");
            }

            return NoContent();
        }
    }

}
