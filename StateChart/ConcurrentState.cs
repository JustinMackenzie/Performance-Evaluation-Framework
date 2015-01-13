using System;
using System.Collections.Generic;

namespace UmlStateChart
{
    /// <summary>
    /// A concurrent state is a type of state that contains atleast two active
    /// parallel sub-states.
    /// </summary>
    public class ConcurrentState : Context
    {
        /// <summary>
        /// The collection of sub-regions in this concurrent state.
        /// </summary>
        private IList<HierarchicalState> _regions;

        /// <summary>
        /// A constructor for the concurrent state.
        /// </summary>
        /// <param name="name">The name of the concurrent state.</param>
        /// <param name="parent">The parent of the concurrent state,</param>
        /// <param name="entry">The action to perform upon entry into the state.</param>
        /// <param name="exit">The action to perform upon exiting from the state.</param>
        public ConcurrentState(String name, Context parent, IAction entry, IAction exit)
            : base(name, parent, entry, exit)
        {
            _regions = new List<HierarchicalState>();
        }

        /// <summary>
        /// Adds given hierarchical state (region) to the collection of regions in the concurrent state.
        /// </summary>
        /// <param name="state">The hierarchical state to be added to the concurrent state.</param>
        public void AddRegion(HierarchicalState state)
        {
            _regions.Add(state);
        }

        /// <summary>
        /// Activates this concurrent state and all of its regions in the given data container.
        /// </summary>
        /// <param name="dataContainer">The data container that holds the run time data.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Deactivates this concurrent state and all of its regions in the given data container.
        /// </summary>
        /// <param name="dataContainer">The data container that holds the run time data.</param>
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

        /// <summary>
        /// Dispatches the given state chart event into the concurrent state. The event is 
        /// dispatched to the active state in each region.
        /// </summary>
        /// <param name="dataContainer">The data container that holds the run time data.</param>
        /// <param name="stateChartEvent">The state chart event to be dispatched and processed.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Determines if this concurrent state is finished, by checking if all regions are
        /// finished.
        /// </summary>
        /// <param name="dataContainer">The data container that holds the run time data.</param>
        /// <returns></returns>
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
