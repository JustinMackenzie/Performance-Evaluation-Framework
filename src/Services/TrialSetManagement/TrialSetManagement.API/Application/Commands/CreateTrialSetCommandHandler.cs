using System.Threading.Tasks;
using BuildingBlocks.EventBus.Abstractions;
using MediatR;
using TrialSetManagement.API.Events.Events;
using TrialSetManagement.Domain;

namespace TrialSetManagement.API.Application.Commands
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MediatR.IAsyncRequestHandler{ScenarioManagement.API.Application.Commands.CreateTrialSetCommand, ScenarioManagement.Domain.TrialSet}" />
    public class CreateTrialSetCommandHandler : IAsyncRequestHandler<CreateTrialSetCommand, TrialSet>
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
        /// Initializes a new instance of the <see cref="CreateTrialSetCommandHandler"/> class.
        /// </summary>
        /// <param name="trialSetRepository">The trial set repository.</param>
        /// <param name="eventBus">The event bus.</param>
        public CreateTrialSetCommandHandler(ITrialSetRepository trialSetRepository, IEventBus eventBus)
        {
            _trialSetRepository = trialSetRepository;
            _eventBus = eventBus;
        }

        /// <summary>
        /// Handles the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public Task<TrialSet> Handle(CreateTrialSetCommand message)
        {
            TrialSet trialSet = new TrialSet(message.Name);
            this._trialSetRepository.Add(trialSet);

            this._eventBus.Publish(new TrialSetCreatedEvent(trialSet.Id, trialSet.Name));

            return Task.FromResult(trialSet);
        }
    }
}