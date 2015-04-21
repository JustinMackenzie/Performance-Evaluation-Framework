using System;
using System.Collections.Generic;
using ScenarioSim.Core.Entities;
using ScenarioSim.Services.Simulator;

namespace ScenarioSim.Infrastructure.SimulationComponents
{
    public class StateChartComponent : ISimulationComponent
    {
        private IStateChartBuilder builder;
        private IStateChartEngine engine;

        public bool IsActive { get { return engine.IsActive; } }

        public StateChartComponent(IStateChartBuilder builder)
        {
            this.builder = builder;
        }

        public void Start(Scenario scenario)
        {
            engine = builder.Build(scenario);
            engine.Start();
        }

        public void SubmitEvent(ScenarioEvent e)
        {
            engine.Dispatch(engine.MakeStateChartEvent(e));
        }

        public void Complete()
        {
            
        }

        public IEnumerable<string> ActiveTasks()
        {
            return engine.ActiveStates();
        }

        public bool IsTaskActive(string task)
        {
            return engine.IsStateActive(task);
        }
    }
}
