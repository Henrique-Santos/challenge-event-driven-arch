using EDA.Core.Domain;

namespace EDA.Wallet.Domain.Models;

public class Account : Entity
{
    public decimal Balance { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    // EF Relation
    public Client Client { get; private set; }  

    // EF
    protected Account() { }

    public Account(Guid id, Client client)
    {
        Id = id;
        Balance = 1_000_000_000;
        CreatedAt = DateTime.Now;
        Client = client;
        Validate();
    }

    public Account(Client client)
    {
        Balance = 1_000_000_000;
        CreatedAt = DateTime.Now;
        Client = client;
        Validate();
    }

    public void Credit(decimal amount)
    {
        Balance += amount;
        UpdatedAt = DateTime.Now;
    }

    public void Debit(decimal amount)
    {
        Balance -= amount;
        UpdatedAt = DateTime.Now;
    }

    private void Validate() 
    {
        Validations.ValidateIfNull(Client, $"{nameof(Client)} cannot be null");
    }
}