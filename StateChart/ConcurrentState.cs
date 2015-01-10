using System;
using System.Collections.Generic;

namespace ScenarioSim.StateChart
{
    public class ConcurrentState : Context
    {
        IList<HierarchicalState> _regions;

        public ConcurrentState(String name, Context parent, IAction entry, IAction exit)
            : base(name, parent, entry, exit)
        {
            _regions = new List<HierarchicalState>();
        }

        public void AddRegion(HierarchicalState state)
        {
            _regions.Add(state);
        }

        public override Boolean Activate(StateDataContainer dataContainer)
        {
            if (base.Activate(dataContainer))
            {
                StateData data = dataContainer.GetStateData(this);

                for (int i = 0; i < _regions.Count; i++)
                {
                    if (!data.StateSet.Contains(_regions[i]))
                    {
                        HierarchicalState hState = _regions[i];

                        if (hState.Activate(dataContainer))
                        {
                            hState.Dispatch(dataContainer, null);
                        }
                    }
                }

                return true;
            }

            return false;
        }

        public override void Deactivate(StateDataContainer dataContainer)
        {
            dataContainer.GetStateData(this).StateSet.Clear();

            for (int i = 0; i < _regions.Count; i++)
            {
                HierarchicalState hState = _regions[i];
                hState.Deactivate(dataContainer);
            }

            base.Deactivate(dataContainer);
        }

        public override bool Dispatch(StateDataContainer dataContainer, StateChartEvent stateChartEvent)
        {
            // at least one region must dispatch the event
            Boolean dispatched = false;

            StateData data = dataContainer.GetStateData(this);

            /*
             * Dispatch the event in all regions as long as this state is active. If we
             * do not check this, an implicit exist would be ignored by this code.
             */

            for (int i = 0; i < _regions.Count && data.Active; i++)
            {
                HierarchicalState hState = _regions[i];

                if (hState.Dispatch(dataContainer, stateChartEvent))
                {
                    dispatched = true;
                }
            }

            if (dispatched)
            {
                return true;
            }

            /*
             * Dispatch the event on this state. but make sure that all regions are
             * finished before we can leave this state with the final-transition.
             */

            for (int i = 0; i < _transitions.Count && data.Active; i++)
            {
                Transition transition = _transitions[i];

                if (transition.StateChartEvent == null && !Finished(dataContainer))
                {
                    continue;
                }

                if (transition.Execute(stateChartEvent, dataContainer))
                {
                    return true;
                }
            }

            return false;
        }

        private Boolean Finished(StateDataContainer dataContainer)
        {
            for (int i = 0; i < _regions.Count; i++)
            {
                HierarchicalState hState = _regions[i];

                if (!(dataContainer.GetStateData(hState).CurrentState is FinalState))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
