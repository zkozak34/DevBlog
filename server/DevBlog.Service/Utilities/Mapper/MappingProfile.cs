using AutoMapper;
using DevBlog.Entities.Concrete;
using DevBlog.Entities.Dtos.Category;
using DevBlog.Entities.Dtos.Post;
using DevBlog.Entities.Dtos.User;

namespace DevBlog.Service.Utilities.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<AppUser, UserDto>().ReverseMap();

            CreateMap<Post, PostDto>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
