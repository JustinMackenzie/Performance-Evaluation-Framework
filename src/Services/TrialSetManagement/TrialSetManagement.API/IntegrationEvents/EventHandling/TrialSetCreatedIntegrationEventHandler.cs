using System.Threading.Tasks;
using BuildingBlocks.EventBus.Abstractions;
using TrialSetManagement.API.Application.Queries;
using TrialSetManagement.API.Events.Events;
using TrialSetManagement.API.Repositories;

namespace TrialSetManagement.API.Events.EventHandling
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BuildingBlocks.EventBus.Abstractions.IEventHandler{ScenarioManagement.API.Events.Events.ScenarioCreatedEvent}" />
    public class TrialSetCreatedEventHandler : IEventHandler<TrialSetCreatedEvent>
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly ITrialSetQueryRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TrialSetCreatedEventHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public TrialSetCreatedEventHandler(ITrialSetQueryRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Handles the specified @event.
        /// </summary>
        /// <param name="event">The @event.</param>
        /// <returns></returns>
        public async Task Handle(TrialSetCreatedEvent @event)
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
