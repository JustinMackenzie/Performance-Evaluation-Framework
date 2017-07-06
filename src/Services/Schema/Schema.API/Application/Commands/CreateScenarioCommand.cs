using System;
using MediatR;
using Schema = Schema.Domain.Schema;

namespace Schema.API.Application.Commands
{
    public class CreateScenarioCommand : IRequest
    {
        public Guid SchemaId { get; set; }
        public string Name { get; set; }
    }
}