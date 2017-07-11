using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Schema.API.Application.Commands
{
    public class CreateSchemaEventCommand : IRequest
    {
        public Guid SchemaId { get; set; }
        public string Name { get; set; }
    }
}
