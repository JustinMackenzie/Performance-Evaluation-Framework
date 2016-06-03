using System.Collections.Generic;
using ScenarioSim.Core.Entities;
using ScenarioSim.Services.Simulator;
using UmlStateChart;

namespace ScenarioSim.Infrastructure.UmlStateChart
{
    public class UmlStateChartEngine : IStateChartEngine
    {
        StateChart stateChart;
        StateDataContainer dataContainer;

        public bool IsActive { get { return !IsStateActive("Evaluate"); } }

        public IStateChartEvent MakeStateChartEvent(ScenarioEvent e)
        {
            return new UmlStateChartEvent()
            {
                Id = e.Id,
                Name = e.Name,
                Timestamp = e.Timestamp
            };
        }

        public void AddAction(ActionPoint actionPoint, string state, IStateChartAction action)
        {
            State s = stateChart.States[state];

            switch (actionPoint)
            {
                case ActionPoint.Entry:
                    if (s.EntryAction == null)
                    {
                        s.EntryAction = new UmlStateChartAction(action);
                    }
                    else
                    {
                        UmlStateChartAction stateChartAction = s.EntryAction as UmlStateChartAction;
                        if (stateChartAction != null)
                            stateChartAction.AddAction(new UmlStateChartAction(action));
                    }

                    break;
                case ActionPoint.Exit:
                    if (s.ExitAction == null)
                    {
                        s.ExitAction = new UmlStateChartAction(action);
                    }
                    else
                    {
                        UmlStateChartAction stateChartAction = s.ExitAction as UmlStateChartAction;
                        if (stateChartAction != null)
                            stateChartAction.AddAction(new UmlStateChartAction(action));
                    }
                    break;
            }
        }

        public UmlStateChartEngine(StateChart stateChart)
        {
            this.stateChart = stateChart;
        }

        public bool IsStateActive(string name)
        {
            State state = stateChart.States[name];

            return dataContainer.ActiveStates().Contains(state);
        }

        public void Dispatch(IStateChartEvent e)
        {
            stateChart.Dispatch(dataContainer, TransformToStateChartEvent(e));
        }

        public List<string> ActiveStates()
        {
            List<string> result = new List<string>();

            foreach (State s in dataContainer.ActiveStates())
            {
                result.Add(s.Name);
            }

            return result;
        }

        public void Start()
        {
            dataContainer = new StateDataContainer();

            stateChart.Start(dataContainer);
        }

        private StateChartEvent TransformToStateChartEvent(IStateChartEvent e)
        {
            return new StateChartEvent(e.Id);
        }
    }
}
