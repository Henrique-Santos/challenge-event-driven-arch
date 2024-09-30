using EDA.Core.Messages;
using EDA.Wallet.Domain.Models;
using EDA.Wallet.Domain.Repository;
using MediatR;

namespace EDA.Wallet.Application.Commands;

public class ClientCommandHandler : CommandHandler, IRequestHandler<CreateClientCommand, bool>
{
    private readonly IClientRepository _repository;

    public ClientCommandHandler(IClientRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(CreateClientCommand message, CancellationToken cancellationToken)
    {
        if (!message.IsValid()) return false;

        var client = new Client(message.Id, message.Name, message.Email);

        await _repository.Save(client);

        return await PersistData(_repository.UnitOfWork);
    }
}