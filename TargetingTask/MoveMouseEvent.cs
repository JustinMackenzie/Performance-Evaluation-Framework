using System;
using ScenarioSim.Core.Entities;

namespace TargetingTask
{
    public class MoveMouseEvent : ScenarioEvent
    {
        public MoveMouseEvent(int x, int y)
        {
            Id = 3;
            Name = "Move Mouse Event";
            Timestamp = DateTime.Now;
            Description = string.Format("The trainne has moved the mouse to ({0},{1}).", x, y);
            Parameters = new EventParameterCollection
            {
                new EventParameter {Name = "X", Value = x},
                new EventParameter {Name = "Y", Value = y}
            };
        }
    }
}