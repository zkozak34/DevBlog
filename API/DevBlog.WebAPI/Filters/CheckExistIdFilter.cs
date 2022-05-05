using DevBlog.Core.Dtos.ResponseDto;
using DevBlog.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DevBlog.WebAPI.Filters
{
    public class CheckExistIdFilter : ActionFilterAttribute
    {
        private readonly IPostRepository _postRepository;

        public CheckExistIdFilter(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var id = int.Parse(context.HttpContext.Request.RouteValues["id"]!.ToString()!);
            Console.WriteLine(id);

            var idExist = await _postRepository.GetById(id);
            if (idExist != null)
            {
                await next.Invoke();
                return;
            }
            context.Result = new NotFoundObjectResult(ResponseDto<NoContent>.Fail("NOT FOUND!", 404));
        }
    }
}
