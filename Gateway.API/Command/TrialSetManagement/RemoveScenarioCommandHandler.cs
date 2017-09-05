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
    /// <seealso cref="MediatR.IAsyncRequestHandler{ScenarioManagement.API.Application.Commands.RemoveScenarioCommand}" />
    public class RemoveScenarioCommandHandler : IAsyncRequestHandler<RemoveScenarioCommand>
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
        /// Initializes a new instance of the <see cref="RemoveScenarioCommandHandler"/> class.
        /// </summary>
        /// <param name="trialSetRepository">The trial set repository.</param>
        /// <param name="eventBus">The event bus.</param>
        public RemoveScenarioCommandHandler(ITrialSetRepository trialSetRepository, IEventBus eventBus)
        {
            _trialSetRepository = trialSetRepository;
            _eventBus = eventBus;
        }

        /// <summary>
        /// Handles the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public async Task Handle(RemoveScenarioCommand message)
        {
            TrialSet trialSet = await this._trialSetRepository.Get(message.TrialSetId);
            trialSet.RemoveScenario(message.ScenarioId);
            await this._trialSetRepository.Update(trialSet);

            this._eventBus.Publish(new ScenarioRemovedFromTrialEvent(message.TrialSetId, message.ScenarioId));
        }
    }
}