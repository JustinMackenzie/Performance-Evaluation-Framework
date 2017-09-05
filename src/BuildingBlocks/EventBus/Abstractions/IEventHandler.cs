using System.Threading.Tasks;
using BuildingBlocks.EventBus.Events;

namespace BuildingBlocks.EventBus.Abstractions
{
    public interface IEventHandler<in TEvent> : IEventHandler 
        where TEvent: Event
    {
        Task Handle(TEvent @event);
    }

    public interface IEventHandler
    {
    }
}
