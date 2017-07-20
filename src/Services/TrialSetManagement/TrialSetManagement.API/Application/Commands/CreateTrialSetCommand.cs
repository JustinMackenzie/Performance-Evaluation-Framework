using MediatR;
using TrialSetManagement.Domain;

namespace TrialSetManagement.API.Application.Commands
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MediatR.IRequest{ScenarioManagement.Domain.TrialSet}" />
    public class CreateTrialSetCommand : IRequest<TrialSet>
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
