using Microsoft.EntityFrameworkCore;
using Orders.Domain.Entities;
using Orders.Infrastructure.Configurations;
using Orders.Infrastructure.Outbox;

namespace Orders.Infrastructure.Contexts;

public sealed class OrdersContext : DbContext
{
	public OrdersContext(DbContextOptions<OrdersContext> options) : base(options)
	{

	}

	public DbSet<Order> Orders { get; set; }
	public DbSet<OutboxMessage> OutboxMessages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
    }
}
