using System.Linq;
using System.Threading.Tasks;
using BuildingBlocks.EventBus.Abstractions;
using ScenarioManagement.API.Application.Queries;
using ScenarioManagement.API.IntegrationEvents.Events;
using ScenarioManagement.API.Repositories;

namespace ScenarioManagement.API.IntegrationEvents.EventHandlers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BuildingBlocks.EventBus.Abstractions.IIntegrationEventHandler{ScenarioManagement.API.IntegrationEvents.Events.ScenarioAssetRemovedEvent}" />
    public class ScenarioAssetRemovedEventHandler : IIntegrationEventHandler<ScenarioAssetRemovedEvent>
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly IScenarioQueryRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioAssetRemovedEventHandler"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public ScenarioAssetRemovedEventHandler(IScenarioQueryRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Handles the specified event.
        /// </summary>
        /// <param name="event">The event.</param>
        /// <returns></returns>
        public async Task Handle(ScenarioAssetRemovedEvent @event)
        {
            ScenarioDto scenario = await this._repository.Get(@event.ScenarioId);
            ScenarioAssetDto asset = scenario.Assets.FirstOrDefault(a => a.Tag == @event.Tag);

            if (asset == null)
            {
                return;
            }

            scenario.Assets.Remove(asset);
            await this._repository.Update(scenario);
        }
    }
}