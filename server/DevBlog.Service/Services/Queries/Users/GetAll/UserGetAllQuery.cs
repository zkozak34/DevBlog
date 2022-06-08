using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Dtos.User;
using MediatR;

namespace DevBlog.Service.Services.Queries.Users.GetAll
{
    public class UserGetAllQuery : IRequest<ResponseDto<IEnumerable<UserDto>>>
    {
    }
}
