﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using BuildingBlocks.EventBus.Abstractions;
using Microsoft.Extensions.Logging;
using PerformanceEvaluation.API.IntegrationEvents.Events;

namespace PerformanceEvaluation.API.IntegrationEvents.EventHandlers
{
    public class TrialAddedEventHandler : IEventHandler<TrialAddedEvent>
    {
        /// <summary>
        /// The scenario service
        /// </summary>
        private readonly IScenarioService _scenarioService;
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
        /// <param name="scenarioService">The scenario service.</param>
        public TrialAddedEventHandler(ITrialAnalysisRepository repository, IScenarioService scenarioService, ILogger<TrialAddedEventHandler> logger)
        {
            this._repository = repository;
            this._scenarioService = scenarioService;
            this._logger = logger;
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
                Scenario scenario = await this._scenarioService.GetScenario(@event.ScenarioId);
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
                        AssetQueryDto asset = scenario.Assets.First(a => a.Tag == $"Target {currentTarget}");

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
                            UserId = @event.UserId
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