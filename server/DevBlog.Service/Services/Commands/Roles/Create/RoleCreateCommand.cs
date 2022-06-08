using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevBlog.Core.Dtos.ResponseDto;
using MediatR;

namespace DevBlog.Service.Services.Commands.Roles.Create
{
    public class RoleCreateCommand : IRequest<ResponseDto<NoContent>>
    {
        public string RoleName { get; set; }
    }
}
