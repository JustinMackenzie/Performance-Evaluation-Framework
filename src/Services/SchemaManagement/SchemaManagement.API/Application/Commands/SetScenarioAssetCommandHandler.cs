using System.Threading.Tasks;
using BuildingBlocks.EventBus.Abstractions;
using MediatR;
using SchemaManagement.API.IntegrationEvents.Events;
using SchemaManagement.Domain;

namespace SchemaManagement.API.Application.Commands
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MediatR.IAsyncRequestHandler{SchemaManagement.API.Controllers.SetScenarioAssetCommand, SchemaManagement.Domain.ScenarioAsset}" />
    public class SetScenarioAssetCommandHandler : IAsyncRequestHandler<SetScenarioAssetCommand, ScenarioAsset>
    {
        /// <summary>
        /// The schema repository
        /// </summary>
        private readonly ISchemaRepository _schemaRepository;

        /// <summary>
        /// The event bus
        /// </summary>
        private readonly IEventBus _eventBus;

        /// <summary>
        /// Initializes a new instance of the <see cref="SetScenarioAssetCommandHandler"/> class.
        /// </summary>
        /// <param name="schemaRepository">The schema repository.</param>
        /// <param name="eventBus">The event bus.</param>
        public SetScenarioAssetCommandHandler(ISchemaRepository schemaRepository, IEventBus eventBus)
        {
            _schemaRepository = schemaRepository;
            _eventBus = eventBus;
        }

        /// <summary>
        /// Handles the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public Task<ScenarioAsset> Handle(SetScenarioAssetCommand message)
        {
            Schema schema = this._schemaRepository.Get(message.SchemaId);
            ScenarioAsset asset = schema.SetAssetInScenario(message.ScenarioId, message.AssetId, message.Position.ToVector(), message.Rotation.ToVector(), message.Rotation.ToVector());

            this._eventBus.Publish(new ScenarioAssetSetIntegrationEvent(schema.Id, message.ScenarioId, message.AssetId, message.Position, message.Rotation, message.Scale));

            return System.Threading.Tasks.Task.FromResult(asset);
        }
    }
}