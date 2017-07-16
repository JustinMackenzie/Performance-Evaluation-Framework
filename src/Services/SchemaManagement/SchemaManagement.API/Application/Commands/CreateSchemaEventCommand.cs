using System;
using MediatR;
using SchemaManagement.Domain;

namespace SchemaManagement.API.Application.Commands
{
    public class CreateSchemaEventCommand : IRequest<Event>
    {
        public Guid SchemaId { get; set; }
        public string Name { get; set; }
    }
}
