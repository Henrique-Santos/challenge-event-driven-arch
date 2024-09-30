using EDA.Wallet.Contracts;
using EDA.Wallet.Domain.Repository;

namespace EDA.Wallet.Application.Queries;

public class ClientQueries : IClientQueries 
{
    private readonly IClientRepository _repository;

    public ClientQueries(IClientRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetClientResponse> GetClient(Guid id)
    {
        var client = await _repository.Get(id);
        if (client is null) return null;
        return new GetClientResponse(client.Id, client.Name, client.Email, client.CreatedAt, client.UpdatedAt);
    }
}