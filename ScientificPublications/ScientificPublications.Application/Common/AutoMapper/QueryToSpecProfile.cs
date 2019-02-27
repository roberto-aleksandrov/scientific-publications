using AutoMapper;
using ScientificPublications.Application.AutoMapper.Converters;
using ScientificPublications.Application.Common.Requests;
using ScientificPublications.Application.Spcifications;

namespace ScientificPublications.Application.AutoMapper
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
