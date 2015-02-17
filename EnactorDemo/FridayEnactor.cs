using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
