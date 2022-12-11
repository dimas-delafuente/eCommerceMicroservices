using Common.Primitives.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Orders.Infrastructure.Interceptors;

internal sealed class AuditEntityInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        DbContext? dbContext = eventData.Context;

        if (dbContext is null)
        {
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        IEnumerable<EntityEntry<IAuditableEntity>> entries = dbContext.ChangeTracker.Entries<IAuditableEntity>();
        foreach (var entityEntry in entries)
        {
            switch (entityEntry.State)
            {
                case EntityState.Added:
                    entityEntry.Property(p => p.CreatedOnUtc).CurrentValue = DateTime.UtcNow;
                    break;

                case EntityState.Modified:
                    entityEntry.Property(p => p.ModifiedOnUtc).CurrentValue = DateTime.UtcNow;
                    break;

            }
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
