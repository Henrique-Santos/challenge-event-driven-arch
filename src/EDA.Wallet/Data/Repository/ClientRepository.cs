using EDA.Core.Data;
using EDA.Wallet.Domain.Models;
using EDA.Wallet.Domain.Repository;

namespace EDA.Wallet.Data.Repository;

public class ClientRepository : IClientRepository
{
    private readonly WalletContext _context;

    public ClientRepository(WalletContext context)
    {
        _context = context;
    }

    public IUnitOfWork UnitOfWork => _context;

    public async Task<Client> Get(Guid id)
    {
        return await _context.Clients.FindAsync(id);
    }

    public async Task Save(Client client)
    {
        await _context.Clients.AddAsync(client);
    }
}