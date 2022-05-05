using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevBlog.Core.Dtos.ResponseDto;
using MediatR;

namespace DevBlog.Service.Services.Commands.Posts.Delete
{
    public class PostDeleteCommand : IRequest<ResponseDto<NoContent>>
    {
        public int Id { get; set; }
    }
}
