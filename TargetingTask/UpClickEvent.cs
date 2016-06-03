using System;
using ScenarioSim.Core.Entities;

namespace TargetingTask
{
    public class UpClickEvent : ScenarioEvent
    {
        public UpClickEvent(int x, int y)
        {
            Id = 1;
            Name = "Upclick Event";
            Timestamp = DateTime.Now;
            Description = string.Format("The trainee has upclicked the mouse at ({0},{1}).", x, y);
            Parameters = new EventParameterCollection
            {
                new EventParameter {Name = "X", Value = x},
                new EventParameter {Name = "Y", Value = y}
            };
        }
    }
}