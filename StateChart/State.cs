using System;
using System.Collections.Generic;

namespace ScenarioSim.StateChart
{
    public class State
    {
        public IAction EntryAction { get; set; }
        public IAction ExitAction { get; set; }
        public Context Context { get; set; }
        public String Name { get; set; }
        public StateChart StateChart { get; set; }

        protected IList<Transition> _transitions;

        public State(String name, Context parent, IAction entry, IAction exit)
        {
            if (parent == null && !(this is StateChart))
            {
                // Exception
            }

            if (name == null)
            {
                // Exception
            }

            Context = parent;

            if (parent != null)
            {
                while (parent.Context != null)
                {
                    parent = parent.Context;
                }

                if (parent is StateChart)
                {
                    StateChart = (StateChart)parent;

                    if (StateChart.States.ContainsKey(name))
                    {
                        // Exception
                    }
                    else
                    {
                        StateChart.States.Add(name, this);
                    }
                }
                else
                {
                    // Exception
                }
            }


            Name = name;
            EntryAction = entry;
            ExitAction = exit;
            _transitions = new List<Transition>();
        }

        public virtual Boolean Activate(StateDataContainer dataContainer)
        {
            if (!dataContainer.IsActive(this))
            {
                dataContainer.Activate(this);

                // trigger the timout events if available
                /*for(int i = 0; i < transitions.size(); i++)  
                {
                    Transition transition = _transitions[i];

                    if(transition.StateChartEvent != null && transition.StateChartEvent is TimeoutEvent)
                    {
                        TimeoutEvent timeoutEvent = (TimeoutEvent)transition.StateChartEvent;


                    }

                    if(transition.StateChartEvent != null && transition.StateChartEvent is TimeoutEvent) {
                        TimeoutEvent timeoutEvent = (TimeoutEvent)transition.StateChartEvent;          
                        EventQueueEntry entry = new EventQueueEntry(statechart, 
                                                                    this, data, event, parameter,
                                                                    ((TimeoutEvent)event).getTimout());
                        StateRuntimedata runtimedata = data.getData(this);
                        runtimedata.timeoutEvents.add(entry);
                        statechart.timeoutEventQueue.add(entry);
                    }*/


                if (EntryAction != null)
                {
                    EntryAction.Execute(dataContainer);
                }
                /*
                if(doAction != null) {
                    doAction.execute(data, parameter);
                }*/
                return true;
            }
            return false;
        }

        public virtual void Deactivate(StateDataContainer dataContainer)
        {
            dataContainer.Deactivate(this);

            if (ExitAction != null)
            {
                ExitAction.Execute(dataContainer);
            }
        }

        public virtual Boolean Dispatch(StateDataContainer dataContainer, StateChartEvent stateChartEvent)
        {
            for (int i = 0; i < _transitions.Count; i++)
            {
                if (_transitions[i].Execute(stateChartEvent, dataContainer))
                {
                    return true;
                }
            }
            return false;
        }

        public void AddTransition(Transition transition)
        {
            if (transition.HasGuard())
            {
                _transitions.Insert(0, transition);
            }
            else
            {
                _transitions.Add(transition);
            }
        }
    }
}
