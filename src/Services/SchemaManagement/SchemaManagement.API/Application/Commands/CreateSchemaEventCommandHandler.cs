﻿using System.Threading.Tasks;
using BuildingBlocks.EventBus.Abstractions;
using MediatR;
using SchemaManagement.API.IntegrationEvents.Events;
using SchemaManagement.Domain;
using Task = System.Threading.Tasks.Task;

namespace SchemaManagement.API.Application.Commands
{
    public class CreateSchemaEventCommandHandler : IAsyncRequestHandler<CreateSchemaEventCommand, Event>
    {
        private readonly ISchemaRepository _repository;

        private readonly IEventBus _eventBus;

        public CreateSchemaEventCommandHandler(ISchemaRepository repository, IEventBus eventBus)
        {
            _repository = repository;
            _eventBus = eventBus;
        }

        public Task<Event> Handle(CreateSchemaEventCommand message)
        {
            Schema schema = this._repository.Get(message.SchemaId);
            Event @event = schema.AddEvent(message.Name);
            this._repository.Update(schema);

            this._eventBus.Publish(new EventCreatedIntegrationEvent(message.SchemaId, message.Name));

            return Task.FromResult(@event);
        }
    }
}
