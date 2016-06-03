using System.Collections.Generic;
using ScenarioSim.Core.Entities;
using ScenarioSim.Services.Simulator;

namespace ScenarioSim.Infrastructure.SimulationComponents
{
    public class StateChartComponent : ISimulationComponent
    {
        private IStateChartBuilder builder;
        private IStateChartEngine engine;

        private Queue<AddActionData> actionQueue; 

        public bool IsActive { get { return engine.IsActive; } }

        public StateChartComponent(IStateChartBuilder builder)
        {
            this.builder = builder;
            actionQueue = new Queue<AddActionData>();
        }

        public void Start(Scenario scenario)
        {
            engine = builder.Build(scenario);

            while (actionQueue.Count > 0)
            {
                AddActionData data = actionQueue.Dequeue();
                engine.AddAction(data.ActionPoint, data.State, data.Action);
            }

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

        public void AddAction(ActionPoint actionPoint, string state, IStateChartAction action)
        {
            if (engine == null)
            {
                actionQueue.Enqueue(new AddActionData()
                {
                    ActionPoint = actionPoint,
                    State = state,
                    Action = action
                });

                return;
            }

            engine.AddAction(actionPoint, state, action);
        }

        private struct AddActionData
        {
            public ActionPoint ActionPoint { get; set; }
            public string State { get; set; }
            public IStateChartAction Action { get; set; }
        }
    }
}
