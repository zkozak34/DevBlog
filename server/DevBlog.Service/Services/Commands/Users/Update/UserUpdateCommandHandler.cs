using DevBlog.Core.Dtos.ResponseDto;
using MediatR;

namespace DevBlog.Service.Services.Commands.Users.Update
{
    public class UserUpdateCommandHandler : IRequestHandler<UserUpdateCommand, ResponseDto<NoContent>>
    {
        public async Task<ResponseDto<NoContent>> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
        {
            //var entity = await _authorReadRepository.GetByIdAsync(request.Id);
            //entity.Email = request.Email;
            //entity.FullName = request.FullName;
            //entity.Overview = request.Overview;
            //entity.ProfileImage = request.ProfileImage;
            //await _authorWriteRepository.SaveAsync();

            return ResponseDto<NoContent>.Success(204);
        }
    }
}
