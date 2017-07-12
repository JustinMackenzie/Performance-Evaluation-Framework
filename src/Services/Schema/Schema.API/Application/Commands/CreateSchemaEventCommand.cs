using System;
using MediatR;

namespace SchemaManagement.API.Application.Commands
{
    public class CreateSchemaEventCommand : IRequest
    {
        public Guid SchemaId { get; set; }
        public string Name { get; set; }
    }
}
