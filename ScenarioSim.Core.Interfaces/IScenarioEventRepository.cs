using ScenarioSim.Core.Entities;

namespace ScenarioSim.Core.Interfaces
{
    public interface IScenarioEventRepository
    {
        ScenarioEventCollection Events { get; }
        void Save(ScenarioEvent e);
    }
}
