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
    /// <seealso cref="MediatR.IAsyncRequestHandler{SchemaManagement.API.Application.Commands.CreateAssetCommand, SchemaManagement.Domain.Asset}" />
    public class CreateAssetCommandHandler : IAsyncRequestHandler<CreateAssetCommand, Asset>
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
        /// Initializes a new instance of the <see cref="CreateAssetCommandHandler" /> class.
        /// </summary>
        /// <param name="schemaRepository">The schema repository.</param>
        /// <param name="eventBus">The event bus.</param>
        public CreateAssetCommandHandler(ISchemaRepository schemaRepository, IEventBus eventBus)
        {
            _schemaRepository = schemaRepository;
            _eventBus = eventBus;
        }

        /// <summary>
        /// Handles the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public Task<Asset> Handle(CreateAssetCommand message)
        {
            Schema schema = this._schemaRepository.Get(message.SchemaId);
            Asset asset = schema.AddAsset(message.Name, message.Tag);

            this._schemaRepository.Update(schema);

            this._eventBus.Publish(new AssetCreatedIntegrationEvent(asset.Id, schema.Id, asset.Name, asset.Tag));

            return System.Threading.Tasks.Task.FromResult(asset);
        }
    }
}