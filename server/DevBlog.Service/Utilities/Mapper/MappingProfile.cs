using AutoMapper;
using DevBlog.Entities.Concrete;
using DevBlog.Entities.Dtos.Author;
using DevBlog.Entities.Dtos.Category;
using DevBlog.Entities.Dtos.Post;

namespace DevBlog.Service.Utilities.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Author, AuthorDto>().ReverseMap();

            CreateMap<Post, PostDto>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
