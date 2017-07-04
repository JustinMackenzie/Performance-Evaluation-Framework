using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Schema.API.Application.Commands;
using Schema.Domain.Exceptions;

namespace Schema.API.Controllers
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
            _mediator = mediator;
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
                await this._mediator.Send(command);
                return Ok();
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