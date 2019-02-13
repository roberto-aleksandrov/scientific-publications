using AutoMapper;
using MediatR;
using ScientificPublications.Application.Interfaces.Data;
using ScientificPublications.Application.Interfaces.Hasher;
using ScientificPublications.Domain.Entities.Users;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ScientificPublications.Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterUserViewModel>
    {
        private readonly IData _data;
        private readonly IHasher _hasher;
        private readonly IMapper _mapper;

        public RegisterUserCommandHandler(IData data, IHasher hasher, IMapper mapper)
        {
            _data = data;
            _hasher = hasher;
            _mapper = mapper;
        }

        public async Task<RegisterUserViewModel> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var salt = Guid.NewGuid().ToString();
            var user = await _data.Users.AddAsync(new UserEntity
            {
                Username = request.Username,
                Password = _hasher.Create(request.Password, salt),
                Salt = salt
            });

            return _mapper.Map<RegisterUserViewModel>(user);
        }
    }
}
