using EDA.Core.Data;
using EDA.Wallet.Domain.Models;
using EDA.Wallet.Domain.Repository;

namespace EDA.Wallet.Data.Repository;

public class TransactionRepository : ITransactionRepository
{
    private readonly WalletContext _context;

    public TransactionRepository(WalletContext context)
    {
        _context = context;
    }

    public IUnitOfWork UnitOfWork => _context;

    public async Task Create(Transaction transaction)
    {
        await _context.Transactions.AddAsync(transaction);
    }
}