using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Dtos.Author;
using MediatR;

namespace DevBlog.Service.Services.Queries.Authors.GetById
{
    public class AuthorGetByIdQuery : IRequest<ResponseDto<AuthorDto>>
    {
        public Guid Id { get; set; }
    }
}
