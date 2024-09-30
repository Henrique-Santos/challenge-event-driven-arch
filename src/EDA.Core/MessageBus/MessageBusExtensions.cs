using Microsoft.Extensions.DependencyInjection;

namespace EDA.Core.MessageBus;

public static class MessageBusExtensions
{
    public static IServiceCollection AddMessageBus(this IServiceCollection services, string connection)
    {
        if (string.IsNullOrEmpty(connection)) throw new ArgumentNullException($"Connection is required. {connection}");

        services.AddSingleton<IMessageBus>(new MessageBus(connection));

        return services;
    }
}