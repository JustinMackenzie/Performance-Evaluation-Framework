using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.Extensions.Logging;
using TrialManagement.API.Application.Commands;
using TrialManagement.Domain;

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
        /// The logger
        /// </summary>
        private readonly ILogger<TrialController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="TrialController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public TrialController(IMediator mediator, ILogger<TrialController> logger)
        {
            this._mediator = mediator;
            this._logger = logger;
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
                Trial trial = await this._mediator.Send(command);
                return Ok(trial);
            }
            catch (Exception ex)
            {
                this._logger.LogError(0, ex, ex.Message);
                return BadRequest();
            }
        }
    }
}