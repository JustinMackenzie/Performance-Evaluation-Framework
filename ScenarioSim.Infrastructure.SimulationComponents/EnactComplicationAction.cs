using ScenarioSim.Services.Simulator;

namespace ScenarioSim.Infrastructure.SimulationComponents
{
    public class EnactComplicationAction : IStateChartAction
    {
        IComplicationEnactorRepository enactorRepository;
        int complicationId;

        public EnactComplicationAction(IComplicationEnactorRepository enactorRepository, int complicationId)
        {
            this.enactorRepository = enactorRepository;
            this.complicationId = complicationId;
        }

        public void Execute()
        {
            if (!enactorRepository.Contains(complicationId))
                return;
            IComplicationEnactor enactor = enactorRepository.GetEnactor(complicationId);
            enactor.Enact();
        }
    }
}
