using UmlStateChart;

namespace ScenarioSim.Core
{
    class StartTimerStateEntryAction : UmlStateChartAction
    {
        TimeKeeper timeKeeper;
        string name;

        public StartTimerStateEntryAction(TimeKeeper timeKeeper, string name)
        {
            this.timeKeeper = timeKeeper;
            this.name = name;
        }

        protected override void ExecuteAction(StateDataContainer container)
        {
            timeKeeper.StartTimer(name);
        }
    }
}
