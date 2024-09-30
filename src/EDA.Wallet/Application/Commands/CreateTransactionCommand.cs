using EDA.Core.Domain;
using EDA.Core.Messages;

namespace EDA.Wallet.Application.Commands;

public class CreateTransactionCommand : Command
{
    public Guid AccountFromId { get; set; }
    public Guid AccountToId { get; set; }
    public decimal Amount { get; set; }

    public CreateTransactionCommand(Guid accountFromId, Guid accountToId, decimal amount)
    {
        Id = Guid.NewGuid();
        AccountFromId = accountFromId;
        AccountToId = accountToId;
        Amount = amount;
    }

    public override bool IsValid()
    {
        try
        {
            Validations.ValidateIfNull(AccountFromId, $"{nameof(AccountFromId)} is required");
            Validations.ValidateIfNull(AccountToId, $"{nameof(AccountToId)} is required");
            Validations.ValidateIfEmpty(AccountFromId.ToString(), $"{nameof(AccountFromId)} is required");
            Validations.ValidateIfEmpty(AccountToId.ToString(), $"{nameof(AccountToId)} is required");
            Validations.ValidateIfLessThanOrEqual(Amount, 0, $"{nameof(Amount)} must be greater than zero");
            return true;
        }
        catch (DomainException)
        {
            return false;
        }
    }
}