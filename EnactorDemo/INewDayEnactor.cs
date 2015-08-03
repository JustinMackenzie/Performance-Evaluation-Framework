using System;

namespace EnactorDemo
{
    interface INewDayEnactor
    {
        void Enact(NewDayEvent o);
        DayOfWeek Day { get; }
    }
}