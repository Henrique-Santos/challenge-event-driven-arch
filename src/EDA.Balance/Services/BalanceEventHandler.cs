
using System.Text.Json;
using EDA.Core.MessageBus;
using EDA.Core.Messages.Events;

namespace EDA.Balance.Services;

public class BalanceEventHandler : BackgroundService
{
    private readonly IMessageBus _bus;

    public BalanceEventHandler(IMessageBus bus)
    {
        _bus = bus;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await _bus.ConsumerAsync<BalanceUpdatedEvent>("BalanceUpdated", Handle, stoppingToken);
    }

    private async Task Handle(BalanceUpdatedEvent message)
    {
        Console.WriteLine($"{nameof(BalanceUpdatedEvent)} was called");
        Console.WriteLine(JsonSerializer.Serialize(message));
        await Task.CompletedTask;
    }
}