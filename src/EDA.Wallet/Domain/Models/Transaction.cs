using EDA.Core.Domain;

namespace EDA.Wallet.Domain.Models;

public class Transaction : Entity
{
    public Guid AccountFromId { get; set; }
    public Guid AccountToId { get; set; }
    public decimal Amount { get; set; }
    public DateTime CreatedAt { get; set; } 
    public Account AccountFrom { get; private set; }
    public Account AccountTo { get; private set; }

    // EF
    public Transaction() { }

    public Transaction(decimal amount, Account accountFrom, Account accountTo)
    {
        Amount = amount;
        AccountFrom = accountFrom;
        AccountTo = accountTo;
        AccountFromId = accountFrom.Id;
        AccountToId = accountTo.Id;
        CreatedAt = DateTime.Now;
        Validate();
        Commit();
    }

    public void Commit()
    {
        AccountFrom.Debit(Amount);
        AccountTo.Credit(Amount);
    }

    private void Validate() {
        Validations.ValidateIfLessThanOrEqual(Amount, 0, $"{nameof(Amount)} must be greater than zero");
        Validations.ValidateIfLessThan(AccountFrom.Balance, Amount, "Insufficient funds");
    }
}