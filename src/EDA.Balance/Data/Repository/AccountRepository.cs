using EDA.Balance.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace EDA.Balance.Data.Repository;

public class AccountRepository : IAccountRepository
{
    private readonly BalanceContext _context;

    public AccountRepository(BalanceContext context)
    {
        _context = context;
    }

    public async Task<decimal> GetBalance(Guid accountId)
    {
        return await _context.Accounts
            .Where(p => p.Id == accountId)
            .Select(p => p.Balance)
            .FirstOrDefaultAsync();
    }
}