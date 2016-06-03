using System;
using ScenarioSim.Core.Entities;

namespace TargetingTask
{
    public class DownClickEvent : ScenarioEvent
    {
        public DownClickEvent(int x, int y)
        {
            Id = 2;
            Name = "Downclick Event";
            Timestamp = DateTime.Now;
            Description = string.Format("The trainee has downclicked the mouse at ({0},{1}).", x, y);
            Parameters = new EventParameterCollection
            {
                new EventParameter {Name = "X", Value = x},
                new EventParameter {Name = "Y", Value = y}
            };
        }
    }
}