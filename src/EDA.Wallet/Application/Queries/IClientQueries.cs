using EDA.Wallet.Contracts;

namespace EDA.Wallet.Application.Queries;

public interface IClientQueries
{
    Task<GetClientResponse> GetClient(Guid id);
}