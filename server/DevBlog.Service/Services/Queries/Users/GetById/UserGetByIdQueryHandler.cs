using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Dtos.User;
using MediatR;

namespace DevBlog.Service.Services.Queries.Users.GetById
{
    public class UserGetByIdQueryHandler : IRequestHandler<UserGetByIdQuery, ResponseDto<UserDto>>
    {

        public async Task<ResponseDto<UserDto>> Handle(UserGetByIdQuery request, CancellationToken cancellationToken)
        {
            //var responseFromDb = await _authorReadRepository.GetByIdAsync(request.Id, false);
            //if (responseFromDb != null)
            //    return ResponseDto<UserDto>.Success(_mapper.Map<UserDto>(responseFromDb), 200);
            //return ResponseDto<UserDto>.Fail((int)HttpStatusCode.BadRequest);
        }
    }
}
