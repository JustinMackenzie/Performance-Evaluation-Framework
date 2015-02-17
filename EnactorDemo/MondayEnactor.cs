using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
