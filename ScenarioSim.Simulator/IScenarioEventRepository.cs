using ScenarioSim.Core;

namespace ScenarioSim.Simulator
{
    interface IScenarioEventRepository
    {
        ScenarioEventCollection Events { get; }
        void Save(ScenarioEvent e);
    }
}
