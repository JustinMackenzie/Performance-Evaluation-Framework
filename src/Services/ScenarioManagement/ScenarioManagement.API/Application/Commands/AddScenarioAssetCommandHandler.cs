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
        private readonly IProcedureRepository _repository;

        /// <summary>
        /// The event bus
        /// </summary>
        private readonly IEventBus _eventBus;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddScenarioAssetCommandHandler"/> class.
        /// </summary>
        /// <param name="repository">The schema repository.</param>
        /// <param name="eventBus">The event bus.</param>
        public AddScenarioAssetCommandHandler(IProcedureRepository repository, IEventBus eventBus)
        {
            _repository = repository;
            _eventBus = eventBus;
        }

        /// <summary>
        /// Handles the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        public async Task<ScenarioAsset> Handle(AddScenarioAssetCommand command)
        {
            Procedure procedure = await this._repository.Get(command.ProcedureId);
            ScenarioAsset scenarioAsset = procedure.AddScenarioAsset(command.ScenarioId, command.Tag, command.Position.ToVector(),
                command.Rotation.ToVector(), command.Scale.ToVector());
            await this._repository.Update(procedure);

            this._eventBus.Publish(new ScenarioAssetAddedEvent(command.ScenarioId, command.Tag, command.Position, command.Rotation, command.Scale));

            return scenarioAsset;
        }
    }
}