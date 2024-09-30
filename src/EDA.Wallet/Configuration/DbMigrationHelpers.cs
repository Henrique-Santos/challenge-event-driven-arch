using EDA.Core.Configuration;
using EDA.Wallet.Data;
using EDA.Wallet.Domain.Models;

namespace EDA.Wallet.Configuration;

public static class DbMigrationHelpers
{
    public static async Task EnsureSeedData(WebApplication serviceScope)
    {
        var services = serviceScope.Services.CreateScope().ServiceProvider;
        await EnsureSeedData(services);
    }

    public static async Task EnsureSeedData(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();

        var context = scope.ServiceProvider.GetRequiredService<WalletContext>();

        await DbHealthChecker.TestConnection(context);

        if (env.IsDevelopment() || env.IsProduction())
        {
            await context.Database.EnsureCreatedAsync();
            await EnsureSeed(context);
        }
    }

    private static async Task EnsureSeed(WalletContext context)
    {
        if (context.Clients.Any() && context.Accounts.Any()) return;

        await context.Accounts.AddAsync(new Account(Guid.Parse("e4f44483-5672-4c38-8246-e8f1a5e754d0"), new Client(Guid.Parse("f35572f5-f6ea-4c82-8a81-b449c0088ae8"), "Henrique", "henrique@gmail.com")));
        await context.Accounts.AddAsync(new Account(Guid.Parse("a75ca408-9dae-4791-a077-19514aa964d2"), new Client(Guid.Parse("cee78be9-a339-4c0b-95af-aa46cea31e4f"), "Felipe", "felipe@gmail.com")));
        await context.Accounts.AddAsync(new Account(Guid.Parse("514daa34-bc0a-4303-b473-5f78b5f9685f"), new Client(Guid.Parse("331498bb-3d5f-449b-96fe-3783231aa78b"), "Thiago", "thiago@gmail.com")));

        await context.SaveChangesAsync();
    }
} 