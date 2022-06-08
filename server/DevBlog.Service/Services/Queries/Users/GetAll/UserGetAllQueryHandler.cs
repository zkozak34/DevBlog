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

        public async Task<ResponseDto<IEnumerable<UserDto>>> Handle(UserGetAllQuery request, CancellationToken cancellationToken)
        {
            var responseFromDb = _userManager.Users.ToList();
            var users = _mapper.Map<IEnumerable<UserDto>>(responseFromDb);
            foreach (var appUser in responseFromDb)
            {
                var userRoles = await _userManager.GetRolesAsync(appUser);
                var user = users.FirstOrDefault(u => u.Email == appUser.Email);
                user.Role = userRoles[0];
            }

            if (responseFromDb.Any())
                return ResponseDto<IEnumerable<UserDto>>.Success(users, 200);
            return ResponseDto<IEnumerable<UserDto>>.Fail(204);
        }
    }
}
