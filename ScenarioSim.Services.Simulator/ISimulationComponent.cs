using ScenarioSim.Core.Entities;

namespace ScenarioSim.Services.Simulator
{
    /// <summary>
    /// Represents a simulation component that provides custom functionality to the simulator.
    /// </summary>
    public interface ISimulationComponent
    {
        /// <summary>
        /// Starts the component's execution.
        /// </summary>
        void Start();

        /// <summary>
        /// Performs the component's logic when an event is submitted.
        /// </summary>
        /// <param name="e">The scenario event.</param>
        void SubmitEvent(ScenarioEvent e);

        /// <summary>
        /// Completes the component's execution.
        /// </summary>
        void Complete();
    }
}
