

using Application.Core;
using Application.Dtos;
using Application.Mapper.Activity;
using Application.Repository;
using Application.Services;
using MediatR;

namespace Application.Commands.Activity
{
    public class CreateUserRequest : IRequest<Result<UserDto>>
    {
        public required UserDto UserCommand { get; set; }
    }

    public class CreateUserRequestHandler : IRequestHandler<CreateUserRequest, Result<UserDto>>
    {
        private readonly IUserWriteRepository userWriteRepository;
        private readonly IUserReadService userReadService;
        private readonly UserMapper userMapper;

        public CreateUserRequestHandler(IUserWriteRepository userWriteRepository,
            IUserReadService userReadService, UserMapper userMapper)
        {
            this.userWriteRepository = userWriteRepository;
            this.userReadService = userReadService;
            this.userMapper = userMapper;
        }

        public async Task<Result<UserDto>> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var users = await userReadService.GetAllAsync(request.UserCommand, cancellationToken);
            if (users.Any())
            {
                return Result<UserDto>.SetFailure(409, "Cannot create duplicate user", null);
            }
            else
            {
                var user = userMapper.MapToUser(request.UserCommand);
                await this.userWriteRepository.CreateAsync(user, cancellationToken);
                return Result<UserDto>.SetSuccess(this.userMapper.MapToUserDto(user));
            }
        }
    }
}
