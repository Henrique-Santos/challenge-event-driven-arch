using EDA.Core.MessageBus;
using EDA.Core.Messages;
using EDA.Core.Messages.Events;
using EDA.Wallet.Domain.Models;
using EDA.Wallet.Domain.Repository;
using MediatR;

namespace EDA.Wallet.Application.Commands;

public class TransactionCommandHandler : CommandHandler, IRequestHandler<CreateTransactionCommand, bool>
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly IMessageBus _bus;

    public TransactionCommandHandler(ITransactionRepository transactionRepository, IAccountRepository accountRepository, IMessageBus bus)
    {
        _transactionRepository = transactionRepository;
        _accountRepository = accountRepository;
        _bus = bus;
    }

    public async Task<bool> Handle(CreateTransactionCommand message, CancellationToken cancellationToken)
    {
        if (!message.IsValid()) return false;

        var accountFrom = await _accountRepository.Get(message.AccountFromId);

        if (accountFrom is null) return false;

        var accountTo = await _accountRepository.Get(message.AccountToId);

        if (accountTo is null) return false;

        var transaction = new Transaction(message.Amount, accountFrom, accountTo);

        await _transactionRepository.Create(transaction);

        await _bus.ProducerAsync("TransactionCreated", new TransactionCreatedEvent(transaction.Id, transaction.AccountFromId, transaction.AccountToId, transaction.Amount));

        await _bus.ProducerAsync("BalanceUpdated", new BalanceUpdatedEvent(transaction.Id, transaction.AccountFromId, transaction.AccountToId, accountFrom.Balance, accountTo.Balance));

        return await PersistData(_transactionRepository.UnitOfWork);
    }
}