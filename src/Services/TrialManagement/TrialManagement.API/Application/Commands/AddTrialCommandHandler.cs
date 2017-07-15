using System.Threading.Tasks;
using MediatR;
using TrialManagement.Domain;

namespace TrialManagement.API.Application.Commands
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MediatR.IAsyncRequestHandler{TrialManagement.API.Application.Commands.AddTrialCommand}" />
    public class AddTrialCommandHandler : IAsyncRequestHandler<AddTrialCommand>
    {
        /// <summary>
        /// The trial repository
        /// </summary>
        private readonly ITrialRepository _trialRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddTrialCommandHandler"/> class.
        /// </summary>
        /// <param name="trialRepository">The trial repository.</param>
        public AddTrialCommandHandler(ITrialRepository trialRepository)
        {
            this._trialRepository = trialRepository;
        }

        /// <summary>
        /// Handles the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public Task Handle(AddTrialCommand message)
        {
            Trial trial = new Trial(message.ScenarioId, message.Start, message.End);

            foreach (var @event in message.Events)
                trial.AddEvent(new Event(@event.Name, @event.Timestamp, @event.Properties));

            this._trialRepository.Add(trial);

            return Task.CompletedTask;
        }
    }
}
