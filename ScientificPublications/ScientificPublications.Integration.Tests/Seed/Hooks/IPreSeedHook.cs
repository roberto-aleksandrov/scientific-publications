using ScientificPublications.Domain.Entities;

namespace ScientificPublications.Integration.Tests.Seed.Hooks
{
    public interface IPreSeedHook<out T>
        where T : BaseEntity
    {
        T Execute(object entity);
    }
}
