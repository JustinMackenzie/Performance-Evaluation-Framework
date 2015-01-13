using System;

namespace UmlStateChart
{
    public interface IAction
    {
        void Execute(StateDataContainer container);
    }
}


