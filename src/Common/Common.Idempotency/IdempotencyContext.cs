using Microsoft.EntityFrameworkCore;

namespace Common.Idempotency;

internal class IdempotencyContext : DbContext
{
    public IdempotencyContext(DbContextOptions<IdempotencyContext> options) : base(options)
    {

    }

    public DbSet<IdempotentRequest> IdempotencyRequests { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new IdempotentRequestConfiguration());
    }

}