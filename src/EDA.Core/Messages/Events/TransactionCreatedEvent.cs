namespace EDA.Core.Messages.Events;

public class TransactionCreatedEvent : Event
{
    public Guid TransactionId { get; set; }
    public Guid AccountFromId { get; set; }
    public Guid AccountToId { get; set; }
    public decimal Amount { get; set; }

    public TransactionCreatedEvent(Guid transactionId, Guid accountFromId, Guid accountToId, decimal amount)
    {
        TransactionId = transactionId;
        AccountFromId = accountFromId;
        AccountToId = accountToId;
        Amount = amount;
    }
}