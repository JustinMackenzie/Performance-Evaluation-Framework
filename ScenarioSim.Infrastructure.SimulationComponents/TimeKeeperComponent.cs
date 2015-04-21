using System;
using System.Collections.Generic;
using ScenarioSim.Core.Entities;
using ScenarioSim.Services.Simulator;

namespace ScenarioSim.Infrastructure.SimulationComponents
{
    public class TimeKeeperComponent : ISimulationComponent
    {
        Dictionary<string, long> times;
        long previousTime;
        IEnumerable<string> previousTasks;
        private readonly StateChartComponent stateChartComponent;

        public IDictionary<string, long> TaskTimes {
            get { return times; }
        }

        public TimeKeeperComponent(StateChartComponent stateChartComponent)
        {
            this.stateChartComponent = stateChartComponent;
        }

        public void Start(Scenario scenario)
        {
            times = new Dictionary<string, long>();
            previousTasks = stateChartComponent.ActiveTasks();
            previousTime = DateTime.Now.Ticks;
        }

        public void SubmitEvent(ScenarioEvent e)
        {
            long currentTime = e.Timestamp.Ticks;
            long deltaTime = currentTime - previousTime;

            UpdateTimes(deltaTime);

            previousTasks = stateChartComponent.ActiveTasks();
            previousTime = currentTime;
        }

        private void UpdateTimes(long deltaTime)
        {
            foreach (string task in previousTasks)
            {
                if (times.ContainsKey(task))
                    times[task] += deltaTime;
                else
                    times.Add(task, deltaTime);
            }
        }

        public void Complete()
        {
            long currentTime = DateTime.Now.Ticks;
            long deltaTime = currentTime - previousTime;

            UpdateTimes(deltaTime);
        }
    }
}
