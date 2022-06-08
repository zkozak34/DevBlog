using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace DevBlog.Service.Services.Queries.Roles
{
    public class RoleGetAllQueryHandler : IRequestHandler<RoleGetAllQuery, ResponseDto<List<AppRole>>>
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleGetAllQueryHandler(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public Task<ResponseDto<List<AppRole>>> Handle(RoleGetAllQuery request, CancellationToken cancellationToken)
        {
            List<AppRole> roles = _roleManager.Roles.ToList();
            if (roles.Any())
                return Task.FromResult(ResponseDto<List<AppRole>>.Success(roles, 200));
            return Task.FromResult(ResponseDto<List<AppRole>>.Fail(204));
        }
    }
}
