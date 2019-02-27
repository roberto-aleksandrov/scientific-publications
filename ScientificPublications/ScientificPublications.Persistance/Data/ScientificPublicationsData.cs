using ScientificPublications.Application.Interfaces.Data;
using ScientificPublications.Domain.Entities;
using ScientificPublications.Domain.Entities.Publications;
using ScientificPublications.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ScientificPublications.Infrastructure.Data
{
    public class ScientificPublicationsData : IData
    {
        private readonly ScientificPublicationsContext _context;
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public ScientificPublicationsData(
            ScientificPublicationsContext context,
            IAsyncRepository<UserEntity> users,
            IAsyncRepository<CathedralAuthorEntity> cathedralAuthors,
            IAsyncRepository<NonCathedralAuthorEntity> nonCathedralAuthors,
            IAsyncRepository<AuthorEntity> authors,
            IAsyncRepository<PublicationEntity> publications,
            IAsyncRepository<RoleEntity> roles,
            IAsyncRepository<UserRoleEntity> userRoles)
        {
            _context = context;
            Users = users;
            Authors = authors;
            CathedralAuthors = cathedralAuthors;
            NonCathedralAuthors = NonCathedralAuthors;
            Publications = publications;
            Roles = roles;
            UserRoles = userRoles;
            
        }
        
        public IAsyncRepository<UserEntity> Users { get; }

        public IAsyncRepository<AuthorEntity> Authors { get; }

        public IAsyncRepository<CathedralAuthorEntity> CathedralAuthors { get; }

        public IAsyncRepository<NonCathedralAuthorEntity> NonCathedralAuthors { get; }

        public IAsyncRepository<PublicationEntity> Publications { get; }

        public IAsyncRepository<RoleEntity> Roles { get; }

        public IAsyncRepository<UserRoleEntity> UserRoles { get; }

        public IAsyncRepository<TEntity> Repository<TEntity>() 
            where TEntity : BaseEntity
        {
            var entityType = typeof(TEntity);

            if (!_repositories.ContainsKey(entityType))
            {
                var repoProp = GetType()
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .First(n => n.PropertyType.GetGenericArguments()[0] == entityType);

                var repo = repoProp.GetValue(this);

                _repositories.Add(entityType, repo);
            }

            return (IAsyncRepository<TEntity>)_repositories[typeof(TEntity)];
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
