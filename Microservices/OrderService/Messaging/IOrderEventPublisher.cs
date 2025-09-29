using OrderService.Events;

namespace OrderService.Messaging
{
    public interface IOrderEventPublisher
    {
        Task PublishOrderCompletedAsync(OrderCompletedEvent message);
    }
}
