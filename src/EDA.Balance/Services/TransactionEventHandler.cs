
using System.Text.Json;
using EDA.Core.MessageBus;
using EDA.Core.Messages.Events;

namespace EDA.Balance.Services;

public class TransactionEventHandler : BackgroundService
{
    private readonly IMessageBus _bus;

    public TransactionEventHandler(IMessageBus bus)
    {
        _bus = bus;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await _bus.ConsumerAsync<TransactionCreatedEvent>("TransactionCreated", Handle, stoppingToken);
    }

    private async Task Handle(TransactionCreatedEvent message)
    {
        Console.WriteLine($"{nameof(TransactionCreatedEvent)} was called");
        Console.WriteLine(JsonSerializer.Serialize(message));
        await Task.CompletedTask;
    }
}