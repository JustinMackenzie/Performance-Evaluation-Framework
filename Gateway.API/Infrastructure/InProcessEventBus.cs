using System;
using System.Collections.Generic;
using BuildingBlocks.EventBus.Abstractions;
using BuildingBlocks.EventBus.Events;

namespace Gateway.API.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BuildingBlocks.EventBus.Abstractions.IEventBus" />
    public class InProcessEventBus : IEventBus
    {
        /// <summary>
        /// The subscriptions
        /// </summary>
        private readonly Dictionary<Type, List<Action<Event>>> _subscriptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="InProcessEventBus"/> class.
        /// </summary>
        public InProcessEventBus()
        {
            this._subscriptions = new Dictionary<Type, List<Action<Event>>>();
        }

        /// <summary>
        /// Subscribes the specified handler.
        /// </summary>
        /// <typeparam name="TEvent">The type of the event.</typeparam>
        /// <typeparam name="THandler">The type of the handler.</typeparam>
        /// <param name="handler">The handler.</param>
        public void Subscribe<TEvent, THandler>(Func<THandler> handler) where TEvent : Event where THandler : IEventHandler<TEvent>
        {
            if (!this._subscriptions.ContainsKey(typeof(TEvent)))
                this._subscriptions.Add(typeof(TEvent), new List<Action<Event>>());

            this._subscriptions[typeof(TEvent)].Add(@event =>
            {
                THandler h = handler.Invoke();
                TEvent e = (TEvent) @event;
                h.Handle(e);
            });
        }

        /// <summary>
        /// Unsubscribes this instance.
        /// </summary>
        /// <typeparam name="TEvent">The type of the event.</typeparam>
        /// <typeparam name="THandler">The type of the handler.</typeparam>
        /// <exception cref="NotImplementedException"></exception>
        public void Unsubscribe<TEvent, THandler>() where TEvent : Event where THandler : IEventHandler<TEvent>
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Publishes the specified event.
        /// </summary>
        /// <param name="event">The event.</param>
        public void Publish(Event @event)
        {
            if (!this._subscriptions.ContainsKey(@event.GetType()))
                return;

            foreach (Action<Event> action in this._subscriptions[@event.GetType()])
                action.Invoke(@event);
        }
    }
}
