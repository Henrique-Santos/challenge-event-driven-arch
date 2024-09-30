using EDA.Core.Messages;

namespace EDA.Core.MessageBus;

public interface IMessageBus : IDisposable
{
    Task ProducerAsync<T>(string topic, T message) where T : Event;
    Task ConsumerAsync<T>(string topic, Func<T, Task> onMessage, CancellationToken cancellation) where T : Event;
}