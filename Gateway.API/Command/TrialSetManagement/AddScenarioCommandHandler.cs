using System.Threading.Tasks;
using BuildingBlocks.EventBus.Abstractions;
using Gateway.API.Events.TrialSetManagement;
using MediatR;
using TrialSetManagement.Domain;
using TrialSetManagement.Domain.Exceptions;

namespace Gateway.API.Command.TrialSetManagement
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AddScenarioCommand" />
    public class AddScenarioCommandHandler : IAsyncRequestHandler<AddScenarioCommand>
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
        /// Initializes a new instance of the <see cref="AddScenarioCommandHandler" /> class.
        /// </summary>
        /// <param name="trialSetRepository">The trial set repository.</param>
        /// <param name="eventBus">The event bus.</param>
        public AddScenarioCommandHandler(ITrialSetRepository trialSetRepository, IEventBus eventBus)
        {
            _trialSetRepository = trialSetRepository;
            _eventBus = eventBus;
        }

        /// <summary>
        /// Handles the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public async Task Handle(AddScenarioCommand message)
        {
            TrialSet trialSet = await this._trialSetRepository.Get(message.TrialSetId);

            if (trialSet == null)
                throw new TrialSetManagementDomainException("There is no trial set with the given identifier.");

            trialSet.AddScenario(message.ScenarioId);

            await this._trialSetRepository.Update(trialSet);

            this._eventBus.Publish(new ScenarioAddedToTrialSetEvent(message.TrialSetId, message.ScenarioId));
        }
    }
}