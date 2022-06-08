using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Concrete;
using MediatR;

namespace DevBlog.Service.Services.Queries.Roles
{
    public class RoleGetAllQuery : IRequest<ResponseDto<List<AppRole>>>
    {
    }
}
