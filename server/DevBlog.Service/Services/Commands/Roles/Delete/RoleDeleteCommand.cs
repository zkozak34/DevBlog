using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevBlog.Core.Dtos.ResponseDto;
using MediatR;

namespace DevBlog.Service.Services.Commands.Roles.Delete
{
    public class RoleDeleteCommand : IRequest<ResponseDto<NoContent>>
    {
        public string Id { get; set; }
    }
}
