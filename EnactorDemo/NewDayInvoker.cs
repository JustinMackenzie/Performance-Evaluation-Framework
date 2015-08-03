using System;
using System.Collections.Generic;

namespace EnactorDemo
{
    class NewDayInvoker
    {
        Dictionary<DayOfWeek, INewDayEnactor> enactors;

        public NewDayInvoker()
        {
            enactors = new Dictionary<DayOfWeek, INewDayEnactor>();
        }

        public void RegisterEnactor(INewDayEnactor enactor)
        {
            enactors.Add(enactor.Day, enactor);
        }

        public void NewDay(NewDayEvent e)
        {
            if(enactors.ContainsKey(e.Day))
                enactors[e.Day].Enact(e);
        }
    }
}
