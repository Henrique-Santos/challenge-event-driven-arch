using EDA.Core.Data;
using EDA.Wallet.Domain.Models;

namespace EDA.Wallet.Domain.Repository;

public interface IClientRepository : IRepository
{
    Task<Client> Get(Guid id);
    Task Save(Client client);
}