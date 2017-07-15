using System;
using BuildingBlocks.EventBus.Abstractions;
using BuildingBlocks.EventBus.Events;
using RawRabbit;
using RawRabbit.Common;

namespace EventBus.RawRabbit
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BuildingBlocks.EventBus.Abstractions.IEventBus" />
    public class RawRabbitEventBus : IEventBus
    {
        /// <summary>
        /// The bus client
        /// </summary>
        private readonly IBusClient _busClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="RawRabbitEventBus"/> class.
        /// </summary>
        /// <param name="busClient">The bus client.</param>
        public RawRabbitEventBus(IBusClient busClient)
        {
            this._busClient = busClient;
        }

        /// <summary>
        /// Subscribes the specified handler.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TH">The type of the h.</typeparam>
        /// <param name="handler">The handler.</param>
        public void Subscribe<T, TH>(Func<TH> handler) where T : IntegrationEvent where TH : IIntegrationEventHandler<T>
        {
            ISubscription subscription = this._busClient.SubscribeAsync<T>(async (msg, context) =>
            {
                TH h = handler.Invoke();
                await h.Handle(msg);
            });

            subscription.Dispose();
        }

        /// <summary>
        /// Unsubscribes this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TH">The type of the h.</typeparam>
        /// <exception cref="System.ArgumentNullException"></exception>
        public void Unsubscribe<T, TH>() where T : IntegrationEvent where TH : IIntegrationEventHandler<T>
        {
            throw new ArgumentNullException();
        }

        /// <summary>
        /// Publishes the specified event.
        /// </summary>
        /// <param name="event">The event.</param>
        public void Publish(IntegrationEvent @event)
        {
            this._busClient.PublishAsync(@event).Wait();
        }
    }
}
