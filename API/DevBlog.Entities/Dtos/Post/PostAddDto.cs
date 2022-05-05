using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevBlog.Entities.Abstract;

namespace DevBlog.Entities.Dtos.Post
{
    public class PostAddDto : IDto
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string ThumbnailImage { get; set; }

        public int AuthorId { get; set; }

        public int CategoryId { get; set; }
    }
}
