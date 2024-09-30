using MediatR;

namespace EDA.Core.Messages;

public abstract class Command : Message, IRequest<bool>
{
    public DateTime Timestamp { get; private set; }

    protected Command()
    {
        Timestamp = DateTime.Now;
    }

    public abstract bool IsValid();
}