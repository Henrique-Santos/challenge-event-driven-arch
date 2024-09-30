using EDA.Core.Data;

namespace EDA.Core.Messages;

public abstract class CommandHandler
{
    protected async Task<bool> PersistData(IUnitOfWork uow)
    {
        return await uow.Commit();
    }
}