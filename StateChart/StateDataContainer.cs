using System.Collections.Generic;

namespace UmlStateChart
{
    public class StateDataContainer
    {
        IDictionary<State, StateData> _activeStates;

        public StateDataContainer()
        {
            _activeStates = new Dictionary<State, StateData>();
        }

        public bool IsActive(State state)
        {
            if (_activeStates.ContainsKey(state))
            {
                return _activeStates[state].Active;
            }

            return false;
        }

        public StateData CreateStateData(State state)
        {
            StateData data = _activeStates[state];

            if (data == null)
            {
                data = new StateData();
                _activeStates.Add(state, data);
            }

            return data;
        }

        public StateData GetStateData(State state)
        {
            return _activeStates[state];
        }

        public void Activate(State state)
        {
            StateData data = null;

            if (_activeStates.ContainsKey(state))
            {
                data = _activeStates[state];
            }
            else
            {
                data = new StateData();
                _activeStates.Add(state, data);
            }

            data.Active = true;
            data.CurrentState = null;

            if (state.Context != null)
            {
                data = _activeStates[state.Context];
                data.CurrentState = state;
            }
        }

        public void Deactivate(State state)
        {
            if (_activeStates.ContainsKey(state))
            {
                StateData data = GetStateData(state);

                if (state is PseudoState)
                {
                    PseudoState pState = (PseudoState)state;

                    if (pState.PseudoStateType == PseudoStateType.History
                       || pState.PseudoStateType == PseudoStateType.DeepHistory)
                    {
                        data.Active = false;
                        return;
                    }
                }

                /*data.timeoutEvents.clear();*/
                data.CurrentState = null;
                data = null;
                _activeStates.Remove(state);
            }
        }

        public void Reset()
        {
            _activeStates.Clear();
        }

        public IList<State> ActiveStates()
        {
            List<State> result = new List<State>();


            foreach (KeyValuePair<State, StateData> p in _activeStates)
            {
                if (p.Value.Active)
                {
                    State s = p.Key;
                    result.Add(p.Key);
                }
            }

            return result;
        }
    }
}
