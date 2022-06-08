using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<ResponseDto<List<AppRole>>> Handle(RoleGetAllQuery request, CancellationToken cancellationToken)
        {
            List<AppRole> roles = _roleManager.Roles.ToList();
            if(roles.Any())
                return ResponseDto<List<AppRole>>.Success(roles, 200);
            return ResponseDto<List<AppRole>>.Fail(204);
        }
    }
}
