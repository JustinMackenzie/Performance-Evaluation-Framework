﻿using System.Collections.Generic;

namespace UmlStateChart
{
    public class StateData
    {
        public State CurrentState { get; set; }
        public bool Active { get; set; }

        public IList<State> StateSet;

        public StateData()
        {
            StateSet = new List<State>();
        }
    }
}