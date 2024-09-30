namespace EDA.Balance.Domain.Repository;

public interface IAccountRepository
{
    Task<decimal> GetBalance(Guid accountId);
}