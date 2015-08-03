using System;

namespace EnactorDemo
{
    class FridayEnactor : INewDayEnactor
    {
        public void Enact(NewDayEvent o)
        {
            Console.WriteLine("TGIF!");
        }

        public DayOfWeek Day
        {
            get { return DayOfWeek.Friday; }
        }
    }
}
