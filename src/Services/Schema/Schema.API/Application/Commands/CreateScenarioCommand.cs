using System;
using MediatR;
using Schema = SchemaManagement.Domain.Schema;

namespace SchemaManagement.API.Application.Commands
{
    public class CreateScenarioCommand : IRequest
    {
        public Guid SchemaId { get; set; }
        public string Name { get; set; }
    }
}