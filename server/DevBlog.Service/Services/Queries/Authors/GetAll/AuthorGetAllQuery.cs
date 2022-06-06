using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Dtos.Author;
using MediatR;

namespace DevBlog.Service.Services.Queries.Authors.GetAll
{
    public class AuthorGetAllQuery : IRequest<ResponseDto<IEnumerable<AuthorDto>>>
    {
    }
}
