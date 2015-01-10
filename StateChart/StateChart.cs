using System;
using System.Collections.Generic;

namespace ScenarioSim.StateChart
{
    public class StateChart : Context
    {
        public IDictionary<String, State> States
        {
            get
            {
                return _states;
            }
        }

        IDictionary<String, State> _states;

        public StateChart(String name)
            : base(name, null, null, null)
        {
            _states = new Dictionary<String, State>();
        }

        public Boolean Start(StateDataContainer dataContainer)
        {
            dataContainer.Reset();
            dataContainer.Activate(this);
            dataContainer.Activate(_startState);
            return Dispatch(dataContainer, null);
        }

        public Boolean RestoreState(State state, StateDataContainer dataContainer)
        {
            if (dataContainer.IsActive(this))
            {
                return false;
            }

            dataContainer.Reset();

            List<State> path = new List<State>();

            State parent = state;

            do
            {
                path.Insert(0, parent);
                parent = parent.Context;
            } while (parent != null);

            foreach (State s in path)
            {
                s.Activate(dataContainer);
            }

            return true;
        }

        public override Boolean Dispatch(StateDataContainer dataContainer, StateChartEvent stateChartEvent)
        {
            Boolean rc = false;

            State currentState = dataContainer.GetStateData(this).CurrentState;

            rc = currentState.Dispatch(dataContainer, stateChartEvent);

            // call dispatch as long as we hit states with end transitions
            do
            {
                currentState = dataContainer.GetStateData(this).CurrentState;
            } while (currentState != null && currentState.Dispatch(dataContainer, stateChartEvent));

            return rc;
        }

        public State GetState(String name)
        {
            return _states[name];
        }
    }
}
