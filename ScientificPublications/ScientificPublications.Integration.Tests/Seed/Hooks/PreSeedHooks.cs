using ScientificPublications.Domain.Entities;
using ScientificPublications.Domain.Entities.Users;
using System;
using System.Collections.Generic;

namespace ScientificPublications.Integration.Tests.Seed.Hooks
{
    public class PreSeedHooks
    {
        private readonly IDictionary<Type, IPreSeedHook<BaseEntity>> _hooks;

        public PreSeedHooks(IPreSeedHook<UserEntity> userHook)
        {
            _hooks = new Dictionary<Type, IPreSeedHook<BaseEntity>>()
            {
                { typeof(UserEntity), userHook }
            };
        }

        public T ExecuteHook<T>(T entity)
            where T : BaseEntity
        {
            var type = typeof(T);

            return _hooks.ContainsKey(type)
                ? (T)_hooks[type].Execute(entity)
                : entity;
        }

    }
}
