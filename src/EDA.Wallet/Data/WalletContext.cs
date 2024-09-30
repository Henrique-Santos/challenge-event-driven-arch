using EDA.Core.Data;
using EDA.Wallet.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EDA.Wallet.Data;

public class WalletContext : DbContext, IUnitOfWork
{
    public WalletContext(DbContextOptions<WalletContext> options) : base(options) { }

    public DbSet<Client> Clients { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var foreignKeys = entityType.GetForeignKeys();
            foreach (var foreignKey in foreignKeys)
            {
                foreignKey.DeleteBehavior = DeleteBehavior.NoAction;
            }
        }
        
        base.OnModelCreating(modelBuilder);
    }

    public async Task<bool> Commit()
    {
        return await base.SaveChangesAsync() > 0;
    }
}