using Microsoft.EntityFrameworkCore;

namespace EDA.Core.Configuration;

public static class DbHealthChecker
{
    public static async Task TestConnection(DbContext context)
    {
        var maxAttemps = 10;
        var delay = 5000;

        for (int i = 0; i < maxAttemps; i++)
        {
            var canConnect = CanConnect(context);
            if (canConnect)
            {
                return;
            }
            await Task.Delay(delay);
        }
        
        throw new Exception("Error wating database. Check ConnectionString and ensure database exist");
    }

    private static bool CanConnect(DbContext context)
    {
        try
        {
            context.Database.GetAppliedMigrations();
            return true;
        }
        catch
        {
            return false;
        }
    }
}