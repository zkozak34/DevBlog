using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Dtos.User;
using MediatR;

namespace DevBlog.Service.Services.Queries.Users.GetById
{
    public class UserGetByIdQuery : IRequest<ResponseDto<UserDto>>
    {
        public Guid Id { get; set; }
    }
}
