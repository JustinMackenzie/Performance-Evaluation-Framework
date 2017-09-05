using System.Threading.Tasks;
using BuildingBlocks.EventBus.Abstractions;
using Gateway.API.Events.TrialSetManagement;
using MediatR;
using TrialSetManagement.Domain;

namespace Gateway.API.Command.TrialSetManagement
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="DeleteTrialSetCommand" />
    public class DeleteTrialSetCommandHandler : IAsyncRequestHandler<DeleteTrialSetCommand>
    {
        /// <summary>
        /// The trial set repository
        /// </summary>
        private readonly ITrialSetRepository _trialSetRepository;

        /// <summary>
        /// The event bus
        /// </summary>
        private readonly IEventBus _eventBus;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteTrialSetCommandHandler"/> class.
        /// </summary>
        /// <param name="trialSetRepository">The trial set repository.</param>
        /// <param name="eventBus">The event bus.</param>
        public DeleteTrialSetCommandHandler(ITrialSetRepository trialSetRepository, IEventBus eventBus)
        {
            _trialSetRepository = trialSetRepository;
            _eventBus = eventBus;
        }

        /// <summary>
        /// Handles the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public Task Handle(DeleteTrialSetCommand message)
        {
            this._trialSetRepository.Delete(message.TrialSetId);
            this._eventBus.Publish(new TrialSetDeletedEvent(message.TrialSetId));

            return Task.CompletedTask;
        }
    }
}