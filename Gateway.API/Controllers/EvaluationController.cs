using System;
using System.Collections.Generic;
using System.Linq;
using Gateway.API.Query.PerformanceEvaluation;
using MathNet.Numerics.LinearRegression;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Gateway.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Produces("application/json")]
    [Route("api/Evaluation")]
    public class EvaluationController : Controller
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly ITrialAnalysisRepository _repository;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<EvaluationController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="EvaluationController" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="logger">The logger.</param>
        public EvaluationController(ITrialAnalysisRepository repository, ILogger<EvaluationController> logger)
        {
            this._repository = repository;
            this._logger = logger;
        }

        /// <summary>
        /// Gets the specified user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public IActionResult Get([FromQuery] Guid userId, [FromQuery] Guid procedureId, [FromQuery] Guid scenarioId)
        {
            try
            {
                IQueryable<TrialAnalysis> query = this._repository.GetTrialAnalysis();

                if (userId != Guid.Empty)
                {
                    query = query.Where(a => a.UserId == userId);
                }

                if (procedureId != Guid.Empty)
                {
                    query = query.Where(a => a.ProcedureId == procedureId);
                }

                if (scenarioId != Guid.Empty)
                {
                    query = query.Where(a => a.ScenarioId == scenarioId);
                }

                List<TrialAnalysis> result = query.ToList();
                double[] y = result.Select(t => (double)t.Milliseconds / 1000).ToArray();
                double[] x = result.Select(t => Math.Log((2.0 * t.Distance) / t.Width, 2)).ToArray();

                Tuple<double, double> fit = SimpleRegression.Fit(x, y);

                return Ok(new { A = fit.Item1, B = fit.Item2 });
            }
            catch (Exception ex)
            {
                this._logger.LogError(0, ex, ex.Message);
                throw;
            }
        }
    }
}