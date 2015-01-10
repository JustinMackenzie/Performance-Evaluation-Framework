using System;
using System.Collections.Generic;

namespace ScenarioSim.StateChart
{
    public class PseudoState : State
    {
        public PseudoStateType PseudoStateType { get; set; }

        IList<Transition> _incoming;

        public PseudoState(String name, Context parent, PseudoStateType type)
            : base(name, parent, null, null)
        {
            PseudoStateType = type;

            if (type == PseudoStateType.Start)
            {
                if (parent.StartState == null)
                {
                    parent.StartState = this;
                }
                else
                {

                }
            }
            else if (type == PseudoStateType.History || type == PseudoStateType.DeepHistory)
            {
                if (parent is HierarchicalState)
                {
                    HierarchicalState hState = (HierarchicalState)parent;

                    if (hState.History == null)
                    {
                        hState.History = this;
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }

        }

        public override Boolean Activate(StateDataContainer dataContainer)
        {
            dataContainer.Activate(this);

            StateData data = dataContainer.GetStateData(this);

            if (EntryAction != null)
            {
                EntryAction.Execute(dataContainer);
            }

            if (PseudoStateType == PseudoStateType.History || PseudoStateType == PseudoStateType.DeepHistory)
            {
                for (int i = 0; i < data.StateSet.Count; i++)
                {
                    data.StateSet[i].Activate(dataContainer);
                }
            }
            else if (PseudoStateType == PseudoStateType.Fork)
            {
                for (int j = 0; j < _transitions.Count; j++)
                {
                    Transition transition = _transitions[j];

                    if (transition.Guard != null && !transition.Guard.Check(dataContainer))
                    {
                        continue;
                    }

                    for (int i = 0; i < transition.Activate.Count; i++)
                    {
                        if (i + 1 < transition.Activate.Count && transition.Activate[i] is ConcurrentState)
                        {
                            ConcurrentState cState = (ConcurrentState)transition.Activate[i];

                            StateData stateData = dataContainer.CreateStateData(cState);

                            if (!stateData.StateSet.Contains(transition.Activate[i + 1]))
                            {
                                stateData.StateSet.Add(transition.Activate[i + 1]);
                            }
                        }
                    }
                }
            }
            else if (PseudoStateType == PseudoStateType.Join)
            {

            }

            return true;
        }

        public void StoreHistory(StateDataContainer dataContainer)
        {
            StateData data = dataContainer.GetStateData(this);

            if (data != null)
            {
                data.StateSet.Clear();
                PseudoState.Calculate(data.StateSet, dataContainer.GetStateData(Context).CurrentState,
                                      dataContainer, PseudoStateType);

            }
        }

        public void AddIncomingTransition(Transition transition)
        {
            if (_incoming == null)
            {
                _incoming = new List<Transition>();
            }

            _incoming.Add(transition);
        }

        public Boolean LookUp(StateDataContainer dataContainer)
        {
            // check if all incoming transitions can trigger
            if (PseudoStateType == PseudoStateType.Join)
            {
                for (int i = 0; i < _incoming.Count; i++)
                {
                    Transition transition = _incoming[i];
                    StateData data = dataContainer.GetStateData(transition.Deactivate[0]);

                    if (data == null || data != null && !data.Active ||
                       transition.HasGuard() && !transition.Guard.Check(dataContainer))
                    {
                        return false;
                    }
                }
            }

            // check if an outgoing transition can trigger
            for (int i = 0; i < _transitions.Count; i++)
            {
                if (_transitions[i].Allowed(dataContainer))
                {
                    return true;
                }
            }
            return false;
        }

        public override Boolean Dispatch(StateDataContainer dataContainer, StateChartEvent stateChartEvent)
        {
            if (PseudoStateType == PseudoStateType.History || PseudoStateType == PseudoStateType.DeepHistory)
            {
                StateData data = dataContainer.GetStateData(Context);

                if (data != null && data.CurrentState != null && data.CurrentState != this)
                {
                    return data.CurrentState.Dispatch(dataContainer, stateChartEvent);
                }
            }
            else if (PseudoStateType == PseudoStateType.Fork)
            {
                for (int i = 0; i < _transitions.Count; i++)
                {
                    Transition transition = _transitions[i];
                    transition.Execute(stateChartEvent, dataContainer);
                }

                return true;
            }

            return base.Dispatch(dataContainer, stateChartEvent);
        }

        private static void Calculate(IList<State> history, State state,
                                      StateDataContainer dataContainer, PseudoStateType type)
        {
            if (state == null)
            {
                return;
            }

            history.Add(state);

            if (type == PseudoStateType.History)
            {
                return;
            }

            if (state is HierarchicalState)
            {
                StateData data = dataContainer.GetStateData((HierarchicalState)state);

                if (data.CurrentState != null)
                {
                    State subState = data.CurrentState;
                    PseudoState.Calculate(history, subState, dataContainer, type);
                }
            }
        }
    }
}
