using EDA.Core.Messages;

namespace EDA.Core.Mediator;

public interface IMediatorHandler
{
    Task<bool> SendCommand<T>(T command) where T : Command;
}