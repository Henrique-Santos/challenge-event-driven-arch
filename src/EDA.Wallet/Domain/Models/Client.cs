using EDA.Core.Domain;

namespace EDA.Wallet.Domain.Models;

public class Client : Entity
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    // EF
    protected Client() { }

    public Client(Guid id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
        CreatedAt = DateTime.Now;
        Validate();
    }

    public Client(string name, string email)
    {
        Name = name;
        Email = email;
        CreatedAt = DateTime.Now;
        Validate();
    }

    public void Update(string name, string email) 
    {
        Name = name;
        Email = email;
        UpdatedAt = DateTime.Now;
        Validate();
    }

    private void Validate() {
        Validations.ValidateIfEmpty(Name, $"{nameof(Name)} is required");
        Validations.ValidateIfEmpty(Email, $"{nameof(Email)} is required");
    }
}