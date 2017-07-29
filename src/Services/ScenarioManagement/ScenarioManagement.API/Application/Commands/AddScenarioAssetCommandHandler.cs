using System.Threading.Tasks;
using BuildingBlocks.EventBus.Abstractions;
using MediatR;
using ScenarioManagement.API.IntegrationEvents.Events;
using ScenarioManagement.Domain;

namespace ScenarioManagement.API.Application.Commands
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ScenarioAsset" />
    public class AddScenarioAssetCommandHandler : IAsyncRequestHandler<AddScenarioAssetCommand, ScenarioAsset>
    {
        /// <summary>
        /// The schema repository
        /// </summary>
        private readonly IScenarioRepository _scenarioRepository;

        /// <summary>
        /// The event bus
        /// </summary>
        private readonly IEventBus _eventBus;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddScenarioAssetCommandHandler"/> class.
        /// </summary>
        /// <param name="scenarioRepository">The schema repository.</param>
        /// <param name="eventBus">The event bus.</param>
        public AddScenarioAssetCommandHandler(IScenarioRepository scenarioRepository, IEventBus eventBus)
        {
            _scenarioRepository = scenarioRepository;
            _eventBus = eventBus;
        }

        /// <summary>
        /// Handles the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        public async Task<ScenarioAsset> Handle(AddScenarioAssetCommand command)
        {
            Scenario scenario = await this._scenarioRepository.Get(command.ScenarioId);

            ScenarioAsset asset = scenario.AddAsset(command.Tag, command.Position.ToVector(), command.Rotation.ToVector(), command.Scale.ToVector());

            await this._scenarioRepository.Update(scenario);

            this._eventBus.Publish(new ScenarioAssetSetIntegrationEvent(command.ScenarioId, asset.Tag, command.Position, command.Rotation, command.Scale));

            return asset;
        }
    }
}