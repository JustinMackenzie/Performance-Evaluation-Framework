using ScenarioSim.Core.Entities;

namespace ScenarioSim.Services.Playback
{
    /// <summary>
    /// The event enactor is responsible for playing out an event.
    /// </summary>
    public interface IEventEnactor
    {
        /// <summary>
        /// The identifier of the event that this enactor represents.
        /// </summary>
        int EventId { get; set; }

        /// <summary>
        /// Enacts the event.
        /// </summary>
        /// <param name="e">The event to enact.</param>
        void Enact(ScenarioEvent e);
    }
}
