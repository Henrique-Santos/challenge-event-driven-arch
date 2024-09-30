using EDA.Core.Domain;
using EDA.Core.Messages;

namespace EDA.Wallet.Application.Commands;

public class CreateClientCommand : Command
{
    public string Name { get; private set; }
    public string Email { get; private set; }

    public CreateClientCommand(string name, string email)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
    }

    public override bool IsValid()
    {
        try
        {
            Validations.ValidateIfEmpty(Name, $"{nameof(Name)} is required");
            Validations.ValidateIfEmpty(Email, $"{nameof(Email)} is required");
            return true;
        }
        catch (DomainException)
        {
            return false;
        }
    }
}