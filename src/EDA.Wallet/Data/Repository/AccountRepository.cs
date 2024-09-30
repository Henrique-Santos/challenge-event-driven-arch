using EDA.Core.Data;
using EDA.Wallet.Domain.Models;
using EDA.Wallet.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace EDA.Wallet.Data.Repository;

public class AccountRepository : IAccountRepository 
{
    private readonly WalletContext _context;

    public AccountRepository(WalletContext context)
    {
        _context = context;
    }

    public IUnitOfWork UnitOfWork => _context;

    public async Task<Account> Get(Guid id)
    {
        return await _context.Accounts.Include(p => p.Client).FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task Save(Account account)
    {
        await _context.Accounts.AddAsync(account);
    }
}