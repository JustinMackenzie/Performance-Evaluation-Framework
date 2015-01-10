using System;

namespace ScenarioSim.StateChart
{
    public class HierarchicalState : Context
    {
        public PseudoState History
        {
            get
            {
                return _history;
            }
            set
            {
                _history = value;
            }
        }

        PseudoState _history;

        public HierarchicalState(String name, Context parent, IAction entry, IAction exit) :
            base(name, parent, entry, exit)
        {
            _history = null;

            if (parent is ConcurrentState)
            {
                ((ConcurrentState)parent).AddRegion(this);
            }
        }

        public override void Deactivate(StateDataContainer dataContainer)
        {
            if (!dataContainer.IsActive(this))
            {
                return;
            }

            StateData stateData = dataContainer.GetStateData(this);

            if (stateData == null)
            {
                base.Deactivate(dataContainer);
                return;
            }

            if (_history != null
               && stateData.CurrentState != _startState
               && stateData.CurrentState != _history
               && !(stateData.CurrentState is FinalState))
            {
                _history.StoreHistory(dataContainer);
            }

            if (stateData.CurrentState != null)
            {
                stateData.CurrentState.Deactivate(dataContainer);
            }

            stateData.CurrentState = null;

            base.Deactivate(dataContainer);
        }

        public override Boolean Dispatch(StateDataContainer dataContainer, StateChartEvent stateChartEvent)
        {
            if (!dataContainer.IsActive(this))
            {
                return false;
            }

            StateData data = dataContainer.GetStateData(this);

            // Use startstate on activation if available
            if (data.CurrentState == null && _startState != null)
            {
                dataContainer.Activate(_startState);
                data.CurrentState.Activate(dataContainer);
            }

            // delegate event to substate.
            Boolean rc = false;

            if (data.CurrentState != null)
            {
                rc = data.CurrentState.Dispatch(dataContainer, stateChartEvent);
            }

            /*
                * If the substate dispatched the event and we reached the finalstate or this
                * state is no longar active, trigger a new dispatch for the end transition, 
                * otherwise return.
            */
            if ((rc && !(data.CurrentState is FinalState)) || !dataContainer.IsActive(this))
            {
                return rc;
            }

            /*
                * If no substate can handle the event try to find a transition on this state
                * which can. There are 3 possibilities:
                * - The endstate is reached: Call the finishing transition
                * - Handle the event with a transition from this state
                * - Handle the event with a transition inherited from the context
            */

            for (int i = 0; i < _transitions.Count; i++)
            {
                Transition transition = _transitions[i];

                // Filter all finishing transitions if endstate is not active
                if (!(data.CurrentState is FinalState) && !transition.HasEvent())
                {
                    continue;
                }

                /*
                   * If the endstate is active and the transition is a finishing transition 
                   * (it has not event), trigger the transition without the event.
                   * 
                   * Otherwise try to trigger the transition with the event.
                */
                if (data.CurrentState is FinalState && !transition.HasEvent())
                {
                    if (transition.Execute(null, dataContainer))
                    {
                        return true;
                    }
                }

                // try to fire the transision
                if (transition.Execute(stateChartEvent, dataContainer))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

