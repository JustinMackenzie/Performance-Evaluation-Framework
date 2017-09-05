using System;
using System.Runtime.CompilerServices;
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
        private const string ExchangeName = @"ScenarioSim-EventBus";
        /// <summary>
        /// The bus client
        /// </summary>
        private readonly IBusClient _busClient;

        /// <summary>
        /// The repository
        /// </summary>
        private readonly IRawRabbitSubscriptionRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RawRabbitEventBus" /> class.
        /// </summary>
        /// <param name="busClient">The bus client.</param>
        /// <param name="repository">The repository.</param>
        public RawRabbitEventBus(IBusClient busClient, IRawRabbitSubscriptionRepository repository)
        {
            this._busClient = busClient;
            _repository = repository;
        }

        /// <summary>
        /// Subscribes the specified handler.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TH">The type of the h.</typeparam>
        /// <param name="handler">The handler.</param>
        public void Subscribe<T, TH>(Func<TH> handler) where T : Event where TH : IEventHandler<T>
        {
            ISubscription subscription = this._busClient.SubscribeAsync<T>(async (msg, context) =>
            {
                TH h = handler.Invoke();
                await h.Handle(msg);
            },
            cfg => cfg.WithExchange(e => e.WithName(ExchangeName)).WithRoutingKey(typeof(T).Name));

            this._repository.Add(subscription);
        }

        /// <summary>
        /// Unsubscribes this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TH">The type of the h.</typeparam>
        /// <exception cref="System.ArgumentNullException"></exception>
        public void Unsubscribe<T, TH>() where T : Event where TH : IEventHandler<T>
        {
            throw new ArgumentNullException();
        }

        /// <summary>
        /// Publishes the specified event.
        /// </summary>
        /// <param name="event">The event.</param>
        public void Publish(Event @event)
        {
            this._busClient.PublishAsync(@event, configuration: cfg => cfg.WithExchange(e => e.WithName(ExchangeName)).WithRoutingKey(@event.GetType().Name)).Wait();
        }
    }
}
