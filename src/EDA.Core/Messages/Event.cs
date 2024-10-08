using MediatR;

namespace EDA.Core.Messages;

public abstract class Event : Message, INotification
{
    public DateTime Timestamp { get; private set; }

    public Event()
    {
        Timestamp = DateTime.Now;
    }
}