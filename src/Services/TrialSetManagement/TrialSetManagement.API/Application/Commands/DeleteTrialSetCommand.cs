using System;
using MediatR;

namespace TrialSetManagement.API.Application.Commands
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MediatR.IRequest" />
    public class DeleteTrialSetCommand : IRequest
    {
        /// <summary>
        /// Gets or sets the trial set identifier.
        /// </summary>
        /// <value>
        /// The trial set identifier.
        /// </value>
        public Guid TrialSetId { get; set; }
    }
}