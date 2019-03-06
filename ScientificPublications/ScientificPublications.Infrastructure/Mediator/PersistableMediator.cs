using AutoMapper;
using MediatR;
using ScientificPublications.Application.Common.Interfaces.Data;
using ScientificPublications.Application.Common.Models.Mediatr;
using ScientificPublications.Domain.Entities;
using ScientificPublications.Infrastructure.Mediator.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScientificPublications.Infrastructure.Mediator
{
    public class PersistableMediator : IPersistableMediator
    {
        private readonly IData _data;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PersistableMediator(IData data, IMediator mediator, IMapper mapper)
        {
            _data = data;
            _mediator = mediator;
            _mapper = mapper;
        }

        private int GetId<TResponse>(TResponse response)
        {
            try
            {
                return (int)response.GetType()
                        .GetProperties()
                        .FirstOrDefault(p => p.Name == "Id")
                        .GetValue(response);
            }
            catch
            {
                return -1;
            }
        }

        public async Task<TResponse> Send<TResponse>(BaseQuery<TResponse> request)
        {
            return await _mediator.Send(request);
        }

        public async Task<List<int>> Send<TResponse>(BaseCommand<TResponse> request)
        {
            var response = await _mediator.Send(request);

            await _data.SaveChangesAsync();

            var responseType = typeof(TResponse);

            if (responseType.GetInterface(typeof(IEnumerable).ToString()) != null)
            {
                var list = (IEnumerable<BaseEntity>)response;

                return list.Select(GetId)
                    .ToList();
            }

            return new List<int> { GetId(response) };
        }
    }
}
