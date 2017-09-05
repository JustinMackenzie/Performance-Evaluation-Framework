using System;
using MediatR;
using ScenarioManagement.Domain;

namespace Gateway.API.Command.ScenarioManagement
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MediatR.IRequest{ScenarioManagement.Domain.Scenario}" />
    public class CreateScenarioCommand : IRequest<Scenario>
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the procedure identifier.
        /// </summary>
        /// <value>
        /// The procedure identifier.
        /// </value>
        public Guid ProcedureId { get; set; }
    }
}