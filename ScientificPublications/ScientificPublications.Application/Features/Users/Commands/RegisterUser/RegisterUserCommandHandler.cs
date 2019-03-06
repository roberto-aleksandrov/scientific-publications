using AutoMapper;
using ScientificPublications.Application.Common.Interfaces.Data;
using ScientificPublications.Application.Common.Models.Mediatr;
using ScientificPublications.Domain.Entities.Users;
using System.Threading;
using System.Threading.Tasks;

namespace ScientificPublications.Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : BaseRequestHandler<RegisterUserCommand, UserEntity>
    {
        public RegisterUserCommandHandler(IData data, IMapper mapper)
            : base(data, mapper)
        {
        }

        public override async Task<UserEntity> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var userEntity = _mapper.Map<UserEntity>(request);

            await _data.Users.AddAsync(userEntity);

            return userEntity;
        }
    }
}
