using EDA.Wallet.Contracts;

namespace EDA.Wallet.Application.Queries;

public interface IAccountQueries 
{
    Task<GetAccountResponse> GetAccount(Guid id);
}