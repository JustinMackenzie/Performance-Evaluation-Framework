using System;

namespace UmlStateChart
{
    public abstract class Context : State
    {
        public PseudoState StartState
        {
            get
            {
                return _startState;
            }
            set
            {
                _startState = value;
            }
        }

        protected PseudoState _startState;

        public Context(String name, Context parent, IAction entry, IAction exit)
            : base(name, parent, entry, exit)
        {

        }
    }
}
