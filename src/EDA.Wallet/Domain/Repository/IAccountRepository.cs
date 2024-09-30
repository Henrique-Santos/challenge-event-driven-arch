using EDA.Core.Data;
using EDA.Wallet.Domain.Models;

namespace EDA.Wallet.Domain.Repository;

public interface IAccountRepository : IRepository 
{
    Task<Account> Get(Guid id);
    Task Save(Account account);
}