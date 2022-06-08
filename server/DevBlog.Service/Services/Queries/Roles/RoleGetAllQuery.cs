using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Concrete;
using MediatR;

namespace DevBlog.Service.Services.Queries.Roles
{
    public class RoleGetAllQuery : IRequest<ResponseDto<List<AppRole>>>
    {
    }
}
