using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ScientificPublications.Application.Common.Requests;
using ScientificPublications.Application.Interfaces.Data;

namespace ScientificPublications.Application.Features.Scopus.Commands.SyncWithScopus
{
    public class SyncWithScopusCommandHandler : BaseRequestHandler<SyncWithScopusCommand, int>
    {
        public SyncWithScopusCommandHandler(IData data, IMapper mapper) 
            : base(data, mapper)
        {
        }

        public override Task<int> Handle(SyncWithScopusCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
