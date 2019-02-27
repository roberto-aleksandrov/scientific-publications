using AutoMapper;
using ScientificPublications.Application.Interfaces.Data;

namespace ScientificPublications.Application.Common.Services
{
    public class Service
    {
        protected readonly IData _data;
        protected readonly IMapper _mapper;

        public Service(IData data, IMapper mapper)
        {
            _data = data;
            _mapper = mapper;
        }
    }
}
