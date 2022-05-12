using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevBlog.Entities.Abstract;

namespace DevBlog.Entities.Dtos.Author
{
    public class AuthorLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
