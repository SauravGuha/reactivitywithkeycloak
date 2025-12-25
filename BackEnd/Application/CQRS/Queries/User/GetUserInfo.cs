
using Application.Core;
using Application.Dtos;
using Application.Mapper.Activity;
using Application.Services;
using MediatR;

namespace Application.CQRS.Queries.User
{
    public class GetUserInfoRequest : IRequest<Result<UserDto>>
    {
        public required UserDto UserDto { get; set; }
    }

    public class GetUserInfoRequestHandler : IRequestHandler<GetUserInfoRequest, Result<UserDto>>
    {
        private readonly IUserReadService userReadService;
        private readonly UserMapper userMapper;
        public GetUserInfoRequestHandler(IUserReadService userReadService, UserMapper userMapper)
        {
            this.userReadService = userReadService;
            this.userMapper = userMapper;

        }
        public async Task<Result<UserDto>> Handle(GetUserInfoRequest request, CancellationToken cancellationToken)
        {
            var user = await userReadService.GetAllAsync(request.UserDto, cancellationToken);
            if (user.Any())
            {
                return Result<UserDto>.SetSuccess(userMapper.MapToDto(user.FirstOrDefault()!));
            }
            else
            {
                return Result<UserDto>.SetFailure(404, "user not found", null);
            }
        }
    }
}