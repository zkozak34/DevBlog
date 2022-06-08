using AutoMapper;
using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Concrete;
using DevBlog.Entities.Dtos.User;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace DevBlog.Service.Services.Queries.Users.GetAll
{
    public class UserGetAllQueryHandler : IRequestHandler<UserGetAllQuery, ResponseDto<IEnumerable<UserDto>>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public UserGetAllQueryHandler(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public Task<ResponseDto<IEnumerable<UserDto>>> Handle(UserGetAllQuery request, CancellationToken cancellationToken)
        {
            List<AppUser> users = _userManager.Users.ToList();
            if (users.Any())
                return Task.FromResult(
                    ResponseDto<IEnumerable<UserDto>>.Success(_mapper.Map<IEnumerable<UserDto>>(users),200));
            return Task.FromResult(ResponseDto<IEnumerable<UserDto>>.Fail(204));
        }
    }
}
