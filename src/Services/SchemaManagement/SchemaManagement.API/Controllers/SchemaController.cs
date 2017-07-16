using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchemaManagement.API.Application.Commands;
using SchemaManagement.Domain;
using SchemaManagement.Domain.Exceptions;

namespace SchemaManagement.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Schema")]
    public class SchemaController : Controller
    {
        /// <summary>
        /// The mediator
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaController" /> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public SchemaController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        /// <summary>
        /// Creates the schema.
        /// </summary>
        /// <param name="command">The command.</param>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateSchemaCommand command)
        {
            try
            {
                Schema schema = await this._mediator.Send(command);
                return Ok(schema);
            }
            catch (SchemaDomainException e)
            {
                return BadRequest(e.Message);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("{id}/scenario")]
        public async Task<IActionResult> CreateScenario(Guid id, [FromBody] CreateScenarioCommand command)
        {
            try
            {
                command.SchemaId = id;
                Scenario scenario = await this._mediator.Send(command);
                return Ok(scenario);
            }
            catch (SchemaDomainException e)
            {
                return BadRequest(e.Message);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("{id}/event")]
        public async Task<IActionResult> CreateEvent(Guid id, [FromBody] CreateSchemaEventCommand command)
        {
            try
            {
                command.SchemaId = id;
                Event @event = await this._mediator.Send(command);
                return Ok(@event);
            }
            catch (SchemaDomainException e)
            {
                return BadRequest(e.Message);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("{id}/task")]
        public async Task<IActionResult> CreateTask(Guid id, [FromBody] CreateSchemaTaskEventCommand command)
        {
            try
            {
                command.SchemaId = id;
                Domain.Task task = await this._mediator.Send(command);
                return Ok(task);
            }
            catch (SchemaDomainException e)
            {
                return BadRequest(e.Message);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("{id}/tasktransition")]
        public async Task<IActionResult> CreateTaskTransition(Guid id, [FromBody] CreateTaskTransitionCommand command)
        {
            try
            {
                command.SchemaId = id;
                TaskTransition taskTransition = await this._mediator.Send(command);
                return Ok(taskTransition);
            }
            catch (SchemaDomainException e)
            {
                return BadRequest(e.Message);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}