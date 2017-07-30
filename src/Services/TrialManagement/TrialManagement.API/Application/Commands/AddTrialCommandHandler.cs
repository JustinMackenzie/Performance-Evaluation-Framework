﻿using System.Threading.Tasks;
using BuildingBlocks.EventBus.Abstractions;
using MediatR;
using TrialManagement.API.IntegrationEvents.Events;
using TrialManagement.Domain;

namespace TrialManagement.API.Application.Commands
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MediatR.IAsyncRequestHandler{TrialManagement.API.Application.Commands.AddTrialCommand}" />
    public class AddTrialCommandHandler : IAsyncRequestHandler<AddTrialCommand, Trial>
    {
        /// <summary>
        /// The trial repository.
        /// </summary>
        private readonly ITrialRepository _trialRepository;

        /// <summary>
        /// The event bus.
        /// </summary>
        private readonly IEventBus _eventBus;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddTrialCommandHandler"/> class.
        /// </summary>
        /// <param name="trialRepository">The trial repository.</param>
        public AddTrialCommandHandler(ITrialRepository trialRepository, IEventBus eventBus)
        {
            this._trialRepository = trialRepository;
            this._eventBus = eventBus;
        }

        /// <summary>
        /// Handles the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public async Task<Trial> Handle(AddTrialCommand message)
        {
            Trial trial = new Trial(message.ScenarioId, message.UserId, message.Start, message.End);

            foreach (var @event in message.Events)
                trial.AddEvent(new Event(@event.Name, @event.Timestamp, @event.Properties));

            await this._trialRepository.Add(trial);

            this._eventBus.Publish(new TrialAddedIntegrationEvent(
                trial.Id,
                trial.ScenarioId,
                trial.UserId,
                trial.Start,
                trial.End, 
                message.Events));

            return trial;
        }
    }
}
