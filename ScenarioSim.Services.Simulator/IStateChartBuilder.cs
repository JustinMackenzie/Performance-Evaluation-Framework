using ScenarioSim.Core.Entities;

namespace ScenarioSim.Services.Simulator
{
    public interface IStateChartBuilder
    {
        /// <summary>
        /// Builds the state chart from the given scenario.
        /// </summary>
        /// <param name="scenario">The scenario to transform into a state chart.</param>
        /// <returns>A state chart engine with the state chart based off of the scenario.</returns>
        IStateChartEngine Build(Scenario scenario);
    }
}
