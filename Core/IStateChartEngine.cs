using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScenarioSim.Core
{
    public interface IStateChartEngine
    {
        void Dispatch(IStateChartEvent e);

        bool IsStateActive(string name);

        List<string> ActiveStates();

        void Start();

        bool Active { get; }
    }
}
