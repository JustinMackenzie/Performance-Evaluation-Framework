using ScenarioSim.Services.Simulator;
using UmlStateChart;

namespace ScenarioSim.Infrastructure.UmlStateChart
{
    class EnactComplicationAction : UmlStateChartAction
    {
        IComplicationEnactorRepository enactorRepository;
        int complicationId;

        public EnactComplicationAction(IComplicationEnactorRepository enactorRepository, int complicationId)
        {
            this.enactorRepository = enactorRepository;
            this.complicationId = complicationId;
        }

        protected override void ExecuteAction(StateDataContainer container)
        {
            if (!enactorRepository.Contains(complicationId))
                return;
            IComplicationEnactor enactor = enactorRepository.GetEnactor(complicationId);
            enactor.Enact();
        }
    }
}
