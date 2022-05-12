﻿using DevBlog.Entities.Abstract;

namespace DevBlog.Entities.Dtos.Author
{
    public class AuthorDto : IDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string ProfileImage { get; set; }
        public string Overview { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}