using EDA.Core.Data;
using EDA.Wallet.Domain.Models;

namespace EDA.Wallet.Domain.Repository;

public interface ITransactionRepository : IRepository
{
    Task Create(Transaction transaction);
}