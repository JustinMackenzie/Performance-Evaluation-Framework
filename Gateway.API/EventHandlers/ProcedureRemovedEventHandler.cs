﻿using System.Threading.Tasks;
using BuildingBlocks.EventBus.Abstractions;
using Gateway.API.Events.ScenarioManagement;
using Gateway.API.Query.ScenarioManagement;

namespace Gateway.API.EventHandlers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ProcedureRemovedEvent" />
    public class ProcedureRemovedEventHandler : IEventHandler<ProcedureRemovedEvent>
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly IProcedureQueryRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcedureRemovedEventHandler"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public ProcedureRemovedEventHandler(IProcedureQueryRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Handles the specified event.
        /// </summary>
        /// <param name="event">The event.</param>
        /// <returns></returns>
        public async Task Handle(ProcedureRemovedEvent @event)
        {
            await this._repository.Delete(@event.ProcedureId);
        }
    }
}
