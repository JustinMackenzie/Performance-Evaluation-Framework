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
    /// <seealso cref="BuildingBlocks.EventBus.Abstractions.IIntegrationEventHandler{ScenarioManagement.API.IntegrationEvents.Events.ScenarioAssetAddedEvent}" />
    public class ScenarioAssetAddedEventHandler : IIntegrationEventHandler<ScenarioAssetAddedEvent>
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly IScenarioQueryRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioAssetAddedEventHandler"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public ScenarioAssetAddedEventHandler(IScenarioQueryRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Handles the specified event.
        /// </summary>
        /// <param name="event">The event.</param>
        /// <returns></returns>
        public async Task Handle(ScenarioAssetAddedEvent @event)
        {
            ScenarioDto scenario = await this._repository.Get(@event.ScenarioId);

            ScenarioAssetDto asset = new ScenarioAssetDto
            {
                Tag = @event.Tag,
                Position = @event.Position,
                Rotation = @event.Rotation,
                Scale = @event.Scale
            };
            scenario.Assets.Add(asset);

            await this._repository.Update(scenario);
        }
    }
}