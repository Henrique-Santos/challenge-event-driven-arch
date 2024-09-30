using EDA.Balance.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EDA.Balance.Data;

public class BalanceContext : DbContext
{
    public BalanceContext(DbContextOptions<BalanceContext> options) : base(options) { }

    public DbSet<Account> Accounts { get; set; }
}