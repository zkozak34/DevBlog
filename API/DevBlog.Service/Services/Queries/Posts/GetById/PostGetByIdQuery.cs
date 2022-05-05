using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Entities.Concrete;
using MediatR;

namespace DevBlog.Service.Services.Queries.Posts.GetById
{
    public class PostGetByIdQuery: IRequest<ResponseDto<Post>>
    {
        public int Id { get; set; }
    }
}
