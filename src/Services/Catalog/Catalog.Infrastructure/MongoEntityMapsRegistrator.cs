using System.Reflection;
using Catalog.Infrastructure.Configurations;

namespace Catalog.Infrastructure
{
    public static class MongoEntityMapsRegistrator
    {
        public static void RegisterDocumentMaps()
        {
            var assembly = Assembly.GetAssembly(typeof(MongoEntityMapsRegistrator));

            var classMaps = assembly!
                .GetTypes()
                .Where(t => 
                    t.BaseType != null && t.BaseType.IsGenericType &&
                    t.BaseType.GetGenericTypeDefinition() == typeof(EntityDbConfiguration<>));

            foreach (Type? classMap in classMaps)
            {
                _ = Activator.CreateInstance(classMap);
            }
        }
    }
}
