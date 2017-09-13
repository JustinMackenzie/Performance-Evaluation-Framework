using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using BuildingBlocks.EventBus.Abstractions;
using Gateway.API.Command.TrialManagement;
using Gateway.API.Events.TrialManagement;
using Gateway.API.Query.PerformanceEvaluation;
using Gateway.API.Query.ScenarioManagement;
using Microsoft.Extensions.Logging;

namespace Gateway.API.EventHandlers
{
    public class TrialAddedEventHandler : IEventHandler<TrialAddedEvent>
    {
        /// <summary>
        /// The scenario service
        /// </summary>
        private readonly IScenarioQueryRepository _scenarioQueryRepository;

        /// <summary>
        /// The procedure query
        /// </summary>
        private readonly IProcedureQueries _procedureQuery;

        /// <summary>
        /// The repository
        /// </summary>
        private readonly ITrialAnalysisRepository _repository;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<TrialAddedEventHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="TrialAddedEventHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="scenarioQueryRepository">The scenario service.</param>
        public TrialAddedEventHandler(ITrialAnalysisRepository repository, IScenarioQueryRepository scenarioQueryRepository, ILogger<TrialAddedEventHandler> logger, IProcedureQueries procedureQuery)
        {
            this._repository = repository;
            this._scenarioQueryRepository = scenarioQueryRepository;
            this._logger = logger;
            this._procedureQuery = procedureQuery;
        }

        /// <summary>
        /// Handles the specified @event.
        /// </summary>
        /// <param name="event">The @event.</param>
        /// <returns></returns>
        public async Task Handle(TrialAddedEvent @event)
        {
            try
            {
                ScenarioQueryDto scenario = await this._scenarioQueryRepository.Get(@event.ScenarioId);
                ProcedureQueryDto procedure = await this._procedureQuery.GetProcedureByScenarioId(@event.ScenarioId);

                List<EventDto> events = @event.Events.OrderBy(e => e.Timestamp).ToList();
                int currentTarget = 1;
                EventDto taskStartEvent = null;

                foreach (EventDto eventDto in events)
                {
                    if (taskStartEvent == null)
                    {
                        taskStartEvent = eventDto;
                    }

                    if (taskStartEvent != null && eventDto.Name == "MOUSE_CLICKED")
                    {
                        dynamic taskStartProperties = taskStartEvent.Properties;
                        dynamic eventProperties = eventDto.Properties;
                        ScenarioAssetDto asset = scenario.Assets.First(a => a.Tag == $"Target {currentTarget}");

                        float distance = Vector2.Distance(
                            new Vector2((float)taskStartProperties.MouseX, (float)taskStartProperties.MouseY),
                            new Vector2((float)eventProperties.MouseX, (float)eventProperties.MouseY));
                        float width = asset.Scale.X / 2.0f;
                        long milliseconds = eventDto.Timestamp - taskStartEvent.Timestamp;

                        TrialAnalysis analysis = new TrialAnalysis
                        {
                            Distance = distance,
                            Width = width,
                            Milliseconds = milliseconds,
                            TrialId = @event.TrialId,
                            UserId = @event.UserId,
                            ScenarioId = @event.ScenarioId,
                            ProcedureId = procedure.Id
                        };

                        await this._repository.Add(analysis);

                        taskStartEvent = null;
                    }
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(0, ex, ex.Message);
                throw;
            }
        }
    }
}