using DevBlog.Core.Dtos.ResponseDto;
using MediatR;

namespace DevBlog.Service.Services.Commands.Authors.Update
{
    public class AuthorUpdateCommand : IRequest<ResponseDto<NoContent>>
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string ProfileImage { get; set; }
        public string Overview { get; set; }
    }
}
