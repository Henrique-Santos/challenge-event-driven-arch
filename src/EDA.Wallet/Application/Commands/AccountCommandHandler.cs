using EDA.Core.Messages;
using EDA.Wallet.Domain.Models;
using EDA.Wallet.Domain.Repository;
using MediatR;

namespace EDA.Wallet.Application.Commands;

public class AccountCommandHandler : CommandHandler, IRequestHandler<CreateAccountCommand, bool>
{
    private readonly IAccountRepository _accountRepository;
    private readonly IClientRepository _clientRepository;

    public AccountCommandHandler(IAccountRepository accountRepository, IClientRepository clientRepository)
    {
        _accountRepository = accountRepository;
        _clientRepository = clientRepository;
    }

    public async Task<bool> Handle(CreateAccountCommand message, CancellationToken cancellationToken)
    {
        if (!message.IsValid()) return false;

        var client = await _clientRepository.Get(message.Client.Id);

        if (client is null) return false;

        var account = new Account(message.Id, client);

        await _accountRepository.Save(account);

        return await PersistData(_accountRepository.UnitOfWork);
    }
}