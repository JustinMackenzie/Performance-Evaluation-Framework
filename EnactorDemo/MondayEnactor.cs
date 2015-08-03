using System;

namespace EnactorDemo
{
    class MondayEnactor : INewDayEnactor
    {
        public void Enact(NewDayEvent o)
        {
            Console.WriteLine("Oh no it's Monday!");
        }

        public DayOfWeek Day
        {
            get { return DayOfWeek.Monday; }
        }
    }
}
