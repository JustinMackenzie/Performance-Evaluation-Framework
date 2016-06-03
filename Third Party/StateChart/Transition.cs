using System;
using System.Collections.Generic;

namespace UmlStateChart
{
    public class Transition
    {
        public StateChartEvent StateChartEvent { get; set; }
        public IAction Action { get; set; }
        public Guard Guard { get; set; }

        public IList<State> Deactivate { get; set; }

        public IList<State> Activate { get; set; }

        public Transition(State start, State end)
        {
            Initialize(start, end, null, null, null);
        }

        public Transition(State start, State end, StateChartEvent stateChartEvent)
        {
            Initialize(start, end, stateChartEvent, null, null);
        }

        public Transition(State start, State end, Guard guard)
        {
            Initialize(start, end, null, guard, null);
        }


        public Transition(State start, State end, IAction action)
        {
            Initialize(start, end, null, null, action);
        }

        public Transition(State start, State end, StateChartEvent stateChartEvent, Guard guard)
        {
            Initialize(start, end, stateChartEvent, guard, null);
        }

        public Transition(State start, State end, StateChartEvent stateChartEvent, IAction action)
        {
            Initialize(start, end, stateChartEvent, null, action);
        }

        public Transition(State start, State end, Guard guard, IAction action)
        {
            Initialize(start, end, null, guard, action);
        }

        public Transition(State start, State end, StateChartEvent stateChartEvent, Guard guard,
                          IAction action)
        {
            Initialize(start, end, stateChartEvent, guard, action);
        }

        public Boolean HasEvent()
        {
            return StateChartEvent != null ? true : false;
        }

        public Boolean HasGuard()
        {
            return Guard != null ? true : false;
        }

        public Boolean HasAction()
        {
            return Action != null ? true : false;
        }

        public Boolean Execute(StateChartEvent stateChartEvent, StateDataContainer dataContainer)
        {
            // check if the event can be handled
            if (this.StateChartEvent != null && !this.StateChartEvent.Equals(stateChartEvent, dataContainer))
            {
                return false;
            }

            if (this.StateChartEvent != null && stateChartEvent == null)
            {
                return false;
            }

            if (!Allowed(dataContainer))
            {
                return false;
            }

            // deactivate all states
            for (int i = 0; i < Deactivate.Count; i++)
            {
                Deactivate[i].Deactivate(dataContainer);
            }

            // Execute exit-action
            if (Action != null)
            {
                Action.Execute(dataContainer);
            }

            // Activate all new states.
            for (int i = 0; i < Activate.Count; i++)
            {
                /*
                   * check if we activate an concurrent state imlicit and if so make sure
                   * adding the correct region to the list of regions to ignore on
                   * activation. It is activated by this transition.
                   */
                if (i + 1 < Activate.Count && Activate[i] is ConcurrentState)
                {
                    ConcurrentState concurrentState = (ConcurrentState)Activate[i];

                    StateData data = dataContainer.CreateStateData(concurrentState);

                    if (!data.StateSet.Contains(Activate[i + 1]))
                    {
                        data.StateSet.Add(Activate[i + 1]);
                    }
                }

                Activate[i].Activate(dataContainer);
            }
            return true;
        }

        public Boolean Allowed(StateDataContainer dataContainer)
        {
            if (Guard != null && Guard.Check(dataContainer))
            {
                return false;
            }

            /*
             * if target is a pseudostate, call lookup to check if we do not stay in
             * this state. So get the last state in the activate list. end() is behind
             * the last element so we have to select the prior element by using *--.
             */
            State target = (State)Activate[Activate.Count - 1];

            if (target is PseudoState)
            {
                return ((PseudoState)target).LookUp(dataContainer);
            }

            return true;
        }

        private void Initialize(State start, State end, StateChartEvent stateChartEvent, Guard guard,
                          IAction action)
        {
            StateChartEvent = stateChartEvent;
            Guard = guard;
            Action = action;
            Activate = new List<State>();
            Deactivate = new List<State>();


            CalculateStateSet(start, end, Deactivate, Activate);
            start.AddTransition(this);

            if (end is PseudoState)
            {
                PseudoState pState = (PseudoState)end;

                if (pState.PseudoStateType == PseudoStateType.Join)
                {
                    pState.AddIncomingTransition(this);
                }
            }
        }

        private static void CalculateStateSet(State start, State end,
                                              IList<State> deactivate, IList<State> activate)
        {
            // temp vectors for calculating the LCA (least common ancestor)
            IList<State> a = new List<State>();
            IList<State> d = new List<State>();

            // get all states for possible deactivation
            State startState = start;

            while (startState != null)
            {
                d.Insert(0, startState);
                Context context = startState.Context;

                // If context is hierarchical or concurrent state, get it as parent.
                if (context != null && !(context is StateChart))
                {
                    startState = context;
                }
                else
                {
                    startState = null;
                }
            }

            // get all states for possible activation
            State endState = end;

            while (endState != null)
            {
                a.Insert(0, endState);
                Context context = endState.Context;

                // If context is hierarchical or concurrent state, get it as parent.
                if (context != null && !(context is StateChart))
                {
                    endState = context;
                }
                else
                {
                    endState = null;
                }
            }

            /*
             * Get LCA number. It is min-1 by default. Therefore we make sure that if
             * start equals end, we do not get the whole path up to the root node if the
             * state is a substate.
             */

            int min = a.Count < d.Count ? a.Count : d.Count;
            int lca = min - 1;

            // get the LCA-State
            if (start != end)
            {
                // if the first entry is not equal we got the LCA
                for (lca = 0; lca < min; lca++)
                {
                    if (a[lca] != d[lca])
                    {
                        break;
                    }
                }
            }

            // Fill the given vectors for the transition
            for (int j = lca; j < d.Count; j++)
            {
                deactivate.Insert(0, d[j]);
            }

            for (int j = lca; j < a.Count; j++)
            {
                activate.Add(a[j]);
            }
        }
    }
}
