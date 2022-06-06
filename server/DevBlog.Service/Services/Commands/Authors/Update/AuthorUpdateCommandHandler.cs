using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Repository.Abstract.Author;
using MediatR;

namespace DevBlog.Service.Services.Commands.Authors.Update
{
    public class AuthorUpdateCommandHandler : IRequestHandler<AuthorUpdateCommand, ResponseDto<NoContent>>
    {
        private readonly IAuthorWriteRepository _authorWriteRepository;
        private readonly IAuthorReadRepository _authorReadRepository;

        public AuthorUpdateCommandHandler(IAuthorWriteRepository authorWriteRepository, IAuthorReadRepository authorReadRepository)
        {
            _authorWriteRepository = authorWriteRepository;
            _authorReadRepository = authorReadRepository;
        }

        public async Task<ResponseDto<NoContent>> Handle(AuthorUpdateCommand request, CancellationToken cancellationToken)
        {
            var entity = await _authorReadRepository.GetByIdAsync(request.Id);
            entity.Email = request.Email;
            entity.FullName = request.FullName;
            entity.Overview = request.Overview;
            entity.ProfileImage = request.ProfileImage;
            await _authorWriteRepository.SaveAsync();

            return ResponseDto<NoContent>.Success(204);
        }
    }
}
