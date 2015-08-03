using NUnit.Framework;
using ScenarioSim.Core.Entities;
using ScenarioSim.Infrastructure.XmlSerialization;
using ScenarioSim.Infrastructure.UmlStateChart;

namespace ScenarioSim.Infrastructure.SimulationComponents.Tests
{
    [TestFixture]
    public class ActionTimeKeeperComponentTests
    {
        [Test]
        public void TestActionTimeKeeperComponentStart()
        {
            Scenario scenario = new XmlFileSerializer<Scenario>().Deserialize("Longest Axis 1.scenario");

            StateChartComponent stateChartComponent = new StateChartComponent(new UmlStateChartBuilder());

            ActionTimeKeeperComponent timeKeeperComponent = new ActionTimeKeeperComponent(stateChartComponent);


            stateChartComponent.Start(scenario);
            timeKeeperComponent.Start(scenario);
        }
    }
}
