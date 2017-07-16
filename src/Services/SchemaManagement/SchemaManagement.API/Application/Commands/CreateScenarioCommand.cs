using System;
using MediatR;
using SchemaManagement.Domain;
using Schema = SchemaManagement.Domain.Schema;

namespace SchemaManagement.API.Application.Commands
{
    public class CreateScenarioCommand : IRequest<Scenario>
    {
        public Guid SchemaId { get; set; }
        public string Name { get; set; }
    }
}