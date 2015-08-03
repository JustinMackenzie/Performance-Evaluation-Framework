using System.Collections.Generic;
using System.Linq;
using ScenarioSim.Core;

namespace ScenarioSim.Simulator
{
    public abstract class ErrorTrackingComponent : ISimulationComponent
    {
        protected List<ErrorMetricEntry> errors;
        string parameterName;
        Vector3f idealValue;

        public ErrorTrackingComponent(Vector3f idealValue, string parameterName)
        {
            this.idealValue = idealValue;
            this.parameterName = parameterName;
            errors = new List<ErrorMetricEntry>();
        }

        public void Start()
        {
            
        }

        public void SubmitEvent(ScenarioEvent e)
        {
            var parameter = from EventParameter p in e.Parameters
                            where p.Name == parameterName
                            select p;

            if (parameter.Count() == 0)
                return;

            errors.Add(new ErrorMetricEntry()
            {
                Timestamp = e.Timestamp,
                Error = Calculate((Vector3f)parameter.First().Value, idealValue)
            });
        }

        protected abstract float Calculate(Vector3f actual, Vector3f idealValue);

        public void Complete()
        {
            
        }
    }
}
