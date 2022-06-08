using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Concrete;
using MediatR;

namespace DevBlog.Service.Services.Commands.Authors.RoleAssign
{
    public class AuthorRoleAssignCommand : IRequest<ResponseDto<NoContent>>
    {
        public Guid Id { get; set; }
        public string Role { get; set; }
    }
}
