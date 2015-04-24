using ScenarioSim.Core.Entities;
using ScenarioSim.Services.Simulator;

namespace ScenarioSim.Infrastructure.SimulationComponents
{
    public class ActionEnactComplicationComponent : ISimulationComponent
    {
        private StateChartComponent component;
        private IComplicationEnactorRepository repository;

        public ActionEnactComplicationComponent(StateChartComponent component, IComplicationEnactorRepository repository)
        {
            this.component = component;
            this.repository = repository;
        }

        public void Start(Scenario scenario)
        {
            foreach (Complication complication in scenario.Complications)
            {
                if (!(complication is TaskDependantComplication))
                    continue;

                TaskDependantComplication c = (TaskDependantComplication) complication;

                component.AddAction(c.Entry ? ActionPoint.Entry : ActionPoint.Exit, c.TaskName,
                    new EnactComplicationAction(repository, c.Id));
            }
        }

        public void SubmitEvent(ScenarioEvent e)
        {
            
        }

        public void Complete()
        {
            
        }
    }
}
