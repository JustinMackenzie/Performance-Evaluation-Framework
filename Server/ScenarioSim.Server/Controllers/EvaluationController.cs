using ScenarioSim.Services.Evaluation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ScenarioSim.Core.DataTransfer;
using ScenarioSim.Core.Entities;
using ScenarioSim.Services.Logging;
using ScenarioSim.Services.Mapping;
using ScenarioSim.Services.PerformanceManagement;
using ScenarioSim.Services.ScenarioCreator;
using PerformanceEvaluation = ScenarioSim.Core.DataTransfer.PerformanceEvaluation;
using Schema = ScenarioSim.Core.Entities.Schema;

namespace ScenarioSim.Server.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class EvaluationController : Controller
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// The evaluator
        /// </summary>
        private readonly IPerformanceEvaluator evaluator;

        /// <summary>
        /// The manager
        /// </summary>
        private readonly IPerformanceManager manager;

        /// <summary>
        /// The performer manager
        /// </summary>
        private readonly IPerformerManager performerManager;

        /// <summary>
        /// The schema manager
        /// </summary>
        private readonly ISchemaManager schemaManager;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="EvaluationController" /> class.
        /// </summary>
        /// <param name="evaluator">The evaluator.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="manager">The manager.</param>
        /// <param name="performerManager">The performer manager.</param>
        /// <param name="schemaManager">The schema manager.</param>
        /// <param name="mapper">The mapper.</param>
        public EvaluationController(IPerformanceEvaluator evaluator, ILogger logger, IPerformanceManager manager, IPerformerManager performerManager, ISchemaManager schemaManager, IMapper mapper)
        {
            this.evaluator = evaluator;
            this.logger = logger;
            this.manager = manager;
            this.performerManager = performerManager;
            this.schemaManager = schemaManager;
            this.mapper = mapper;
        }

        /// <summary>
        /// Gets the performance evaluation.
        /// </summary>
        /// <param name="performerId">The performer identifier.</param>
        /// <param name="schemaId">The schema identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/Evaluation/PerformerEvaluation/{performerId}/Schema/{schemaId}")]
        public PerformanceEvaluation GetPerformanceEvaluation(Guid performerId, Guid schemaId)
        {
            try
            {
                Performer performer = performerManager.GetPerformer(performerId);
                Schema schema = schemaManager.GetSchema(schemaId);
                IEnumerable<ScenarioPerformance> performances = manager.GetAllPerformances(schema, performer);

                return mapper.Map<ScenarioSim.Services.Evaluation.PerformanceEvaluation, PerformanceEvaluation>(evaluator.GetPerformanceEvaluation(performances));
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets the schema performance evaluation.
        /// </summary>
        /// <param name="schemaId">The schema identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/Evaluation/SchemaEvaluation/{schemaId}")]
        public PerformanceEvaluation GetSchemaPerformanceEvaluation(Guid schemaId)
        {
            try
            {
                Schema schema = schemaManager.GetSchema(schemaId);
                IEnumerable<ScenarioPerformance> performances = manager.GetAllPerformances(schema);

                return
                    mapper.Map<ScenarioSim.Services.Evaluation.PerformanceEvaluation, PerformanceEvaluation>(
                        evaluator.GetPerformanceEvaluation(performances));
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets the performance evaluation.
        /// </summary>
        /// <param name="performances">The performances.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/Evaluation/Evaluate")]
        public PerformanceEvaluation GetPerformanceEvaluation(List<Performance> performances)
        {
            try
            {
                return
                    mapper.Map<ScenarioSim.Services.Evaluation.PerformanceEvaluation, PerformanceEvaluation>(
                        evaluator.GetPerformanceEvaluation(
                            performances.Select(mapper.Map<Performance, ScenarioPerformance>)));
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                throw;
            }
        }
    }
}