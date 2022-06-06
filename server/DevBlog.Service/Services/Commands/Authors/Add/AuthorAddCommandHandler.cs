using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Core.Utilities.Hashing;
using DevBlog.Entities.Concrete;
using DevBlog.Repository.Abstract.Author;
using MediatR;
using System.Net;

namespace DevBlog.Service.Services.Commands.Authors.Add
{
    public class AuthorAddCommandHandler : IRequestHandler<AuthorAddCommand, ResponseDto<NoContent>>
    {
        private readonly IAuthorWriteRepository _authorWriteRepository;

        public AuthorAddCommandHandler(IAuthorWriteRepository authorWriteRepository)
        {
            _authorWriteRepository = authorWriteRepository;
        }

        public async Task<ResponseDto<NoContent>> Handle(AuthorAddCommand request, CancellationToken cancellationToken)
        {
            var responseFromDb = await _authorWriteRepository.AddAsync(new Author()
            {
                FullName = request.FullName,
                Email = request.Email,
                Password = Security.Encrypt(request.Password, ServiceRegistration.SaltKey),
                ProfileImage = request.ProfileImage,
                Overview = request.Overview
            });
            await _authorWriteRepository.SaveAsync();
            if (responseFromDb)
                return ResponseDto<NoContent>.Success(200);
            return ResponseDto<NoContent>.Fail((int)HttpStatusCode.BadRequest);
        }
    }
}
