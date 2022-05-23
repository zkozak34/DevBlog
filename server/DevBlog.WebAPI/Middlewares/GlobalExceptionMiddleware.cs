using DevBlog.Core.Dtos.ResponseDto;
using Microsoft.AspNetCore.Diagnostics;

namespace DevBlog.WebAPI.Middlewares
{
    public static class GlobalExceptionMiddleware
    {
        public static void UseGlobalExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(options =>
            {
                options.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = 500;
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = exceptionFeature.Error;
                    await context.Response.WriteAsJsonAsync<ResponseDto<NoContent>>(
                        ResponseDto<NoContent>.Fail(exception.Message, 500));
                });
            });
        }
    }
}
