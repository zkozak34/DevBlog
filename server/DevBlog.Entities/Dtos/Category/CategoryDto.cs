﻿namespace DevBlog.Entities.Dtos.Category
{
    public class CategoryDto
    {
        public string Title { get; set; }
        public string Path { get; set; }
        public List<Concrete.Post> Posts { get; set; }
    }
}
