namespace EDA.Core.Messages;

public abstract class Message
{
    public Guid Id { get; protected set; }
    public string Type { get; protected set; }

    protected Message()
    {
        Type = GetType().Name;
    }
}