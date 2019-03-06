using AutoMapper;
using ScientificPublications.Application.Common.AutoMapper.Converters;
using ScientificPublications.Application.Common.Models.Mediatr;
using ScientificPublications.Application.Common.Spcifications;

namespace ScientificPublications.Application.Common.AutoMapper
{
    public class QueryToSpecProfile : Profile
    {
        public QueryToSpecProfile()
        {
            CreateMap(typeof(IBaseQuery), typeof(BaseSpecification<>))
                .ConvertUsing(typeof(BaseSpecificationConverter<>));
        }
    }
}
