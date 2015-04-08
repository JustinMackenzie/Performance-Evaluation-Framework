namespace ScenarioSim.Core.Entities
{
    public struct ActualValueLocation
    {
        public int EventId;
        public string ParameterName;

        public ActualValueLocation(int eventId, string paramName)
        {
            EventId = eventId;
            ParameterName = paramName;
        }
    }
}
