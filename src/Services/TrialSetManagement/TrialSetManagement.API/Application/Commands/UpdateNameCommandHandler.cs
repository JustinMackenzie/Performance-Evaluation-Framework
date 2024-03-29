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
    /// <seealso cref="MediatR.IAsyncRequestHandler{ScenarioManagement.API.Controllers.UpdateNameCommand}" />
    public class UpdateNameCommandHandler : IAsyncRequestHandler<UpdateNameCommand>
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
        /// Initializes a new instance of the <see cref="UpdateNameCommandHandler"/> class.
        /// </summary>
        /// <param name="trialSetRepository">The trial set repository.</param>
        /// <param name="eventBus">The event bus.</param>
        public UpdateNameCommandHandler(ITrialSetRepository trialSetRepository, IEventBus eventBus)
        {
            _trialSetRepository = trialSetRepository;
            _eventBus = eventBus;
        }

        /// <summary>
        /// Handles the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public async Task Handle(UpdateNameCommand message)
        {
            TrialSet trialSet = await this._trialSetRepository.Get(message.TrialSetId);
            trialSet.ChangeName(message.Name);
            await this._trialSetRepository.Update(trialSet);

            this._eventBus.Publish(new TrialSetNameChangedEvent(trialSet.Id, trialSet.Name));
        }
    }
}