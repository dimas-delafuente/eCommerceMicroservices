using System.Reflection;
using DbUp;

namespace Discount.Infrastructure.DbUp
{
    internal static class DatabaseMigration
    {
        public static bool Migrate(string connection, int retryCount = 0)
        {
            try
            {
                EnsureDatabase.For.PostgresqlDatabase(connection);

                var upgrader = DeployChanges.To
                    .PostgresqlDatabase(connection)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

                var result = upgrader.PerformUpgrade();

                return result.Successful;
            }
            catch (Exception)
            {
                if (retryCount < 10)
                {
                    retryCount++;
                    Thread.Sleep(2000);
                    Migrate(connection, retryCount);
                }
                throw;
            }

        }
    }
}
