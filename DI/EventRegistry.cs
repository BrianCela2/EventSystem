using DAL.DI;
using Domain.DI;
using Lamar;

namespace DI
{
    internal class EventRegistry:ServiceRegistry
    {
        public EventRegistry() {
            IncludeRegistry<DomainRegistry>();
            IncludeRegistry<RepositoryRegistry>();
        }
    }
}
