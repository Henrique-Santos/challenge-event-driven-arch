namespace EDA.Core.Data;

public interface IUnitOfWork 
{
    Task<bool> Commit();
}