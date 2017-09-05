using MediatR;
using ScenarioManagement.Domain;

namespace Gateway.API.Command.ScenarioManagement
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MediatR.IRequest{ScenarioManagement.Domain.Procedure}" />
    public class CreateProcedureCommand : IRequest<Procedure>
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
    }
}