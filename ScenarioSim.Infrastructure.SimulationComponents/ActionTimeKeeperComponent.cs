using System;
using System.Collections.Generic;
using System.Linq;
using ScenarioSim.Core.Entities;
using ScenarioSim.Services.Simulator;

namespace ScenarioSim.Infrastructure.SimulationComponents
{
    public class ActionTimeKeeperComponent : ISimulationComponent
    {
        private readonly StateChartComponent stateChartComponent;
        private readonly Dictionary<string, long> activeTimes;
        private readonly Dictionary<string, long> inactiveTimes; 

        public ActionTimeKeeperComponent(StateChartComponent stateChartComponent)
        {
            this.stateChartComponent = stateChartComponent;
            activeTimes = new Dictionary<string, long>();
            inactiveTimes = new Dictionary<string, long>();
        }

        public void Start(Scenario scenario)
        {
            scenario.Task.Traverse(RegisterAction);
        }

        public void SubmitEvent(ScenarioEvent e)
        {
            
        }

        public void Complete()
        {
            foreach (string task in activeTimes.Keys.ToList())
                StopTimer(task);
        }
        
        private void RegisterAction(Task task)
        {
            IStateChartAction entryAction = new StartTimerAction(this, task.Name);
            stateChartComponent.AddAction(ActionPoint.Entry, task.Name, entryAction);

            IStateChartAction exitAction = new StopTimerAction(this, task.Name);
            stateChartComponent.AddAction(ActionPoint.Exit, task.Name, exitAction);
        }

        public void StartTimer(string state)
        {
            if (activeTimes.ContainsKey(state))
                return;
            activeTimes.Add(state, DateTime.Now.Ticks);
        }

        public void StopTimer(string state)
        {
            if (!activeTimes.ContainsKey(state))
                return;

            long deltaTime = DateTime.Now.Ticks - activeTimes[state];

            if (inactiveTimes.ContainsKey(state))
                inactiveTimes[state] += deltaTime;
            else
                inactiveTimes.Add(state, deltaTime);

            activeTimes.Remove(state);
        }
    }
}
