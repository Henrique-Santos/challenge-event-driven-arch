using EDA.Core.Domain;
using EDA.Core.Messages;
using EDA.Wallet.Domain.Models;

namespace EDA.Wallet.Application.Commands;

public class CreateAccountCommand : Command
{
    public Client Client { get; set; }

    public CreateAccountCommand(Guid clientId, string clientName, string clientEmail)
    {
        Id = Guid.NewGuid();
        Client = new Client(clientId, clientName, clientEmail);
    }

    public override bool IsValid()
    {
        try
        {
            Validations.ValidateIfNull(Client.Id, "Client Id is required");
            Validations.ValidateIfEmpty(Client.Id.ToString(), "Client Id is required");
            return true;
        }
        catch (DomainException)
        {
            return false;
        }
    }
}