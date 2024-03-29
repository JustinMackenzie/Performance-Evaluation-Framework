using System;
using System.Threading.Tasks;
using Gateway.API.Command.SchemaManagement;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchemaManagement.Domain;
using SchemaManagement.Domain.Exceptions;

namespace Gateway.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Produces("application/json")]
    [Route("api/Schema")]
    public class SchemaController : Controller
    {
        /// <summary>
        /// The mediator
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<SchemaController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaController" /> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public SchemaController(IMediator mediator, ILogger<SchemaController> logger)
        {
            this._mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// Creates the schema.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateSchemaCommand command)
        {
            try
            {
                Schema schema = await this._mediator.Send(command);
                return Ok(schema);
            }
            catch (SchemaDomainException exception)
            {
                this._logger.LogError(0, exception, exception.Message);
                return BadRequest(new { Reason = exception.Message});
            }
            catch (Exception exception)
            {
                this._logger.LogError(0, exception, exception.Message);
                return BadRequest();
            }
        }

        /// <summary>
        /// Creates the event.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="command">The command.</param>
        /// <returns></returns>
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
            catch (SchemaDomainException exception)
            {
                this._logger.LogError(0, exception, exception.Message);
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                this._logger.LogError(0, exception, exception.Message);
                return BadRequest();
            }
        }

        /// <summary>
        /// Creates the task.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("{id}/task")]
        public async Task<IActionResult> CreateTask(Guid id, [FromBody] CreateSchemaTaskEventCommand command)
        {
            try
            {
                command.SchemaId = id;
                SchemaManagement.Domain.Task task = await this._mediator.Send(command);
                return Ok(task);
            }
            catch (SchemaDomainException exception)
            {
                this._logger.LogError(0, exception, exception.Message);
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                this._logger.LogError(0, exception, exception.Message);
                return BadRequest();
            }
        }

        /// <summary>
        /// Creates the task transition.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="command">The command.</param>
        /// <returns></returns>
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
            catch (SchemaDomainException exception)
            {
                this._logger.LogError(0, exception, exception.Message);
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                this._logger.LogError(0, exception, exception.Message);
                return BadRequest();
            }
        }

        /// <summary>
        /// Creates the asset.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("{id}/asset")]
        public async Task<IActionResult> CreateAsset(Guid id, [FromBody] CreateAssetCommand command)
        {
            try
            {
                command.SchemaId = id;
                Asset asset = await this._mediator.Send(command);
                return Ok(asset);
            }
            catch (SchemaDomainException exception)
            {
                this._logger.LogError(0, exception, exception.Message);
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                this._logger.LogError(0, exception, exception.Message);
                return BadRequest();
            }
        }
    }
}