using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmlStateChart;

namespace ScenarioSim.Core
{
    class EnactComplicationAction : UmlStateChartAction
    {
        IComplicationEnactorRepository repository;
        int complicationId;

        public EnactComplicationAction(IComplicationEnactorRepository repository, int complicationId)
        {
            this.repository = repository;
            this.complicationId = complicationId;
        }

        protected override void ExecuteAction(StateDataContainer container)
        {
            if (!repository.Contains(complicationId))
                return;
            IComplicationEnactor enactor = repository.GetEnactor(complicationId);
            enactor.Execute();
        }
    }
}
