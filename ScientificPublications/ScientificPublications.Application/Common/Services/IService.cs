using ScientificPublications.Application.Common.Requests;
using ScientificPublications.Domain.Entities;
using System.Threading.Tasks;

namespace ScientificPublications.Application.Common.Services
{
    public interface IService<TEntity>
        where TEntity : BaseEntity
    {
    }
}
