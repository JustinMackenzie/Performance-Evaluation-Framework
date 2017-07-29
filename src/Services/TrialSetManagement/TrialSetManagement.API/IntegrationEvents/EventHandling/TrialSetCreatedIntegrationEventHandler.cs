using System.Threading.Tasks;
using BuildingBlocks.EventBus.Abstractions;
using TrialSetManagement.API.Application.Queries;
using TrialSetManagement.API.IntegrationEvents.Events;
using TrialSetManagement.API.Repositories;

namespace TrialSetManagement.API.IntegrationEvents.EventHandling
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BuildingBlocks.EventBus.Abstractions.IIntegrationEventHandler{ScenarioManagement.API.IntegrationEvents.Events.ScenarioCreatedIntegrationEvent}" />
    public class TrialSetCreatedIntegrationEventHandler : IIntegrationEventHandler<TrialSetCreatedIntegrationEvent>
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly ITrialSetQueryRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TrialSetCreatedIntegrationEventHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public TrialSetCreatedIntegrationEventHandler(ITrialSetQueryRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Handles the specified @event.
        /// </summary>
        /// <param name="event">The @event.</param>
        /// <returns></returns>
        public async Task Handle(TrialSetCreatedIntegrationEvent @event)
        {
            TrialSetQueryDto trialSetQuery = new TrialSetQueryDto
            {
                Id = @event.TrialSetId,
                Name = @event.Name
            };

            await this._repository.Add(trialSetQuery);
        }
    }
}
