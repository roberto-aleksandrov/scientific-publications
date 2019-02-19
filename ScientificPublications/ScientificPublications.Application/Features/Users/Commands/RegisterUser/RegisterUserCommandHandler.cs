using AutoMapper;
using MediatR;
using ScientificPublications.Application.Common.Requests;
using ScientificPublications.Application.Features.Users.Models;
using ScientificPublications.Application.Interfaces.Data;
using ScientificPublications.Application.Interfaces.Hasher;
using ScientificPublications.Domain.Entities.Users;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ScientificPublications.Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : BaseRequestHandler<RegisterUserCommand, UserDto>
    {
        private readonly IHasher _hasher;

        public RegisterUserCommandHandler(IData data, IMapper mapper, IHasher hasher)
            : base(data, mapper)
        {
            _hasher = hasher;
        }

        public override async Task<UserDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _data.Users.AddAsync(_mapper.Map<UserEntity>(request));

            return _mapper.Map<UserDto>(user);
        }
    }
}
