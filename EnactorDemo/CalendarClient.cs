using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnactorDemo
{
    class CalendarClient
    {
        public CalendarClient(NewDayInvoker invoker)
        {
            invoker.RegisterEnactor(new MondayEnactor());
            invoker.RegisterEnactor(new FridayEnactor());
        }

        public static void Main()
        {
            NewDayInvoker invoker = new NewDayInvoker();
            CalendarClient client = new CalendarClient(invoker);

            invoker.NewDay(new NewDayEvent() { Day = DayOfWeek.Monday });
            invoker.NewDay(new NewDayEvent() { Day = DayOfWeek.Friday });

            Console.ReadLine();
        }
    }
}
