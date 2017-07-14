using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using TrialManagement.API.Application.Commands;

namespace TrialManagement.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Produces("application/json")]
    [Route("api/Trial")]
    public class TrialController : Controller
    {
        /// <summary>
        /// The mediator
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="TrialController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public TrialController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        /// <summary>
        /// Posts the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddTrialCommand command)
        {
            try
            {
                await this._mediator.Send(command);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}