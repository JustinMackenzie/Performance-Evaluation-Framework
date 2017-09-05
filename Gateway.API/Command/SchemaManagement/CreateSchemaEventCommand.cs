using System;
using MediatR;
using SchemaManagement.Domain;

namespace Gateway.API.Command.SchemaManagement
{
    public class CreateSchemaEventCommand : IRequest<Event>
    {
        public Guid SchemaId { get; set; }
        public string Name { get; set; }
    }
}
