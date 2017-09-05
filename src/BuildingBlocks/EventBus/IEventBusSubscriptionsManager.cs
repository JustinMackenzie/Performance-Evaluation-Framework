using System;
using System.Collections.Generic;
using BuildingBlocks.EventBus.Abstractions;
using BuildingBlocks.EventBus.Events;

namespace BuildingBlocks.EventBus
{
    public interface IEventBusSubscriptionsManager
    {
        bool IsEmpty { get; }
        event EventHandler<string> OnEventRemoved;
        void AddSubscription<T, TH>(Func<TH> handler)
           where T : Event
           where TH : IEventHandler<T>;

       void RemoveSubscription<T, TH>()
            where TH : IEventHandler<T>
            where T : Event;
        bool HasSubscriptionsForEvent<T>() where T : Event;
        bool HasSubscriptionsForEvent(string eventName);
        Type GetEventTypeByName(string eventName);
        void Clear();
        IEnumerable<Delegate> GetHandlersForEvent<T>() where T : Event;
        IEnumerable<Delegate> GetHandlersForEvent(string eventName);
    }
}