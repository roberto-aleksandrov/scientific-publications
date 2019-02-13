﻿using ScientificPublications.Domain.Entities;
using ScientificPublications.Domain.Entities.Publications;
using ScientificPublications.Domain.Entities.Users;

namespace ScientificPublications.Application.Interfaces.Data
{
    public interface IData
    {
        IAsyncRepository<UserEntity> Users { get; }

        IAsyncRepository<PublicationEntity> Publications { get; }
    }
}
