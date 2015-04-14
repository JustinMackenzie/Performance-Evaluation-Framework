using ScenarioSim.Core.Entities;

namespace BenchMarkTests
{
    interface ITest
    {
        void Execute(ScenarioEvent e);

        float Result { get; }
    }
}
