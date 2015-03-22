using ScenarioSim.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScenarioSim.Simulator
{
    class TimeKeeperComponent : ISimulationComponent
    {
        IScenarioSimulator simulator;
        Dictionary<string, long> times;
        long previousTime;
        IEnumerable<string> previousTasks;

        public TimeKeeperComponent(IScenarioSimulator simulator)
        {
            this.simulator = simulator;
        }

        public void Start()
        {
            times = new Dictionary<string, long>();
            previousTasks = simulator.ActiveTasks();
            previousTime = DateTime.Now.Ticks;
        }

        public void SubmitEvent(ScenarioEvent e)
        {
            long deltaTime = DateTime.Now.Ticks - previousTime;

            foreach(string task in previousTasks)
                times[task] += deltaTime;

            previousTasks = simulator.ActiveTasks();
            previousTime = DateTime.Now.Ticks;
        }


        public void Complete()
        {
            throw new NotImplementedException();
        }
    }
}
