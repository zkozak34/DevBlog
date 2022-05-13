using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DevBlog.WebAPI.Filters
{
    public class FileExtensionControlFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string fileName = context.HttpContext.Request.Form.Files.GetFile("file").FileName;
            string extensionName = Path.GetExtension(fileName);
            List<string> allowExtension = new() {".png", ".jpg"};
            if (!allowExtension.Exists(e => e == extensionName))
            {
                context.Result = new BadRequestObjectResult("Image format not supported. Only .png or .jpg");
            }
        }
    }
}
