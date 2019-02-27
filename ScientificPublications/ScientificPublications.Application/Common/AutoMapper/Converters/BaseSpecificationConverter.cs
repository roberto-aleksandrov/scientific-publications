using AutoMapper;
using ScientificPublications.Application.Common.Requests;
using ScientificPublications.Application.Spcifications;
using ScientificPublications.Domain.Entities;
using System;
using System.Linq;

namespace ScientificPublications.Application.AutoMapper.Converters
{
    public class BaseSpecificationConverter<T> : ITypeConverter<IBaseQuery, BaseSpecification<T>>
        where T : BaseEntity
    {
        public BaseSpecification<T> Convert(IBaseQuery source, BaseSpecification<T> destination, ResolutionContext context)
        {
            return new BaseSpecification<T>
            {
                IncludeStrings = source.Include.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList()
            };
        }
    }
}
