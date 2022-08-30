using Catalog.Domain.Shared;

namespace Catalog.Infrastructure.Configurations
{
    internal interface IDbConfiguration<T>
        where T : Entity
    {
        void Register();
    }
}
