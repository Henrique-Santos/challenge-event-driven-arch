namespace EDA.Core.Messages.Events;

public class BalanceUpdatedEvent : Event
{
    public Guid TransactionId { get; set; }
    public Guid AccountFromId { get; set; }
    public Guid AccountToId { get; set; }
    public decimal BalanceAccountFrom { get; set; }
    public decimal BalanceAccountTo { get; set; }

    public BalanceUpdatedEvent(Guid transactionId, Guid accountFromId, Guid accountToId, decimal balanceAccountFrom, decimal balanceAccountTo)
    {
        TransactionId = transactionId;
        AccountFromId = accountFromId;
        AccountToId = accountToId;
        BalanceAccountFrom = balanceAccountFrom;
        BalanceAccountTo = balanceAccountTo;
    }
}