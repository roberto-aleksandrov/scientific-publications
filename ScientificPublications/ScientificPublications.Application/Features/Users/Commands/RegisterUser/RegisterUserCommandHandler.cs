using AutoMapper;
using ScientificPublications.Application.Common.Requests;
using ScientificPublications.Application.Common.Services;
using ScientificPublications.Application.Features.Users.Models;
using ScientificPublications.Application.Features.Users.Services.CreateUser;
using ScientificPublications.Application.Interfaces.Data;
using ScientificPublications.Domain.Entities.Users;
using System.Threading;
using System.Threading.Tasks;

namespace ScientificPublications.Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : BaseRequestHandler<RegisterUserCommand, UserDto>
    {
        private readonly IUserService _userService;

        public RegisterUserCommandHandler(IData data, IMapper mapper, IUserService userService)
            : base(data, mapper)
        {
            _userService = userService;
        }

        public override async Task<UserDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.CreateUserAsync(request);

            await _data.SaveChangesAsync();

            return _mapper.Map<UserDto>(user);
        }
    }
}
