using EDA.Core.Domain;

namespace EDA.Balance.Domain.Models;

public class Account : Entity
{
    public decimal Balance { get; set; }
}