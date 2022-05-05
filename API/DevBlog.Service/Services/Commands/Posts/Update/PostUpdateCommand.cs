using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Dtos.Post;
using MediatR;

namespace DevBlog.Service.Services.Commands.Posts.Update
{
    public class PostUpdateCommand : IRequest<ResponseDto<NoContent>>
    {
        public int Id { get; set; }
        public PostUpdateDto PostUpdateDto { get; set; }
    }
}
