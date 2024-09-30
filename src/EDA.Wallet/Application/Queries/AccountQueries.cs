using EDA.Wallet.Contracts;
using EDA.Wallet.Domain.Repository;

namespace EDA.Wallet.Application.Queries;

public class AccountQueries : IAccountQueries 
{
    private readonly IAccountRepository _repository;

    public AccountQueries(IAccountRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetAccountResponse> GetAccount(Guid id)
    {
        var account = await _repository.Get(id);

        if (account is null) return null;

        var client = new AccountClient(account.Client.Name, account.Client.Email, account.Client.CreatedAt, account.Client.UpdatedAt);
        
        return new GetAccountResponse(account.Id, client, account.Balance, account.CreatedAt, account.UpdatedAt);
    }
}