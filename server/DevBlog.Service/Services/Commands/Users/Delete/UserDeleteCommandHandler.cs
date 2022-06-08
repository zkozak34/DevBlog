using DevBlog.Core.Dtos.ResponseDto;
using MediatR;
using System.Net;

namespace DevBlog.Service.Services.Commands.Users.Delete
{
    public class UserDeleteCommandHandler : IRequestHandler<UserDeleteCommand, ResponseDto<NoContent>>
    {
        public async Task<ResponseDto<NoContent>> Handle(UserDeleteCommand request, CancellationToken cancellationToken)
        {
            //var responseFromDb = await _authorWriteRepository.Delete(request.Id);
            //await _authorWriteRepository.SaveAsync();
            //if (responseFromDb)
            //    return ResponseDto<NoContent>.Success(204);
            return ResponseDto<NoContent>.Fail((int)HttpStatusCode.BadRequest);
        }
    }
}
