using System;

namespace UmlStateChart
{
    public interface Guard
    {
        Boolean Check(StateDataContainer dataContainer);
    }
}

