using ScenarioSim.Core.Entities;

namespace ScenarioSim.Services.PerformanceProcessing
{
    /// <summary>
    /// An abstraction to perform a process on a performance.
    /// </summary>
    public interface IPerformanceProcessor 
    {
        /// <summary>
        /// Processes the specified performance.
        /// </summary>
        /// <param name="performance">The performance.</param>
        void Process(ScenarioPerformance performance);
    }
}
