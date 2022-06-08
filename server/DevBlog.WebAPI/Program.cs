using DevBlog.Repository;
using DevBlog.Service;
using DevBlog.Service.Utilities.Storage.LocalStorage;
using DevBlog.WebAPI.Filters;
using DevBlog.WebAPI.Middlewares;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using ServiceRegistration = DevBlog.Repository.ServiceRegistration;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(options => options.AddServerHeader = false);

builder.Services.AddControllers(opts => opts.Filters.Add(new ValidationFilter()))
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining(typeof(DevBlog.Service.ServiceRegistration)));
builder.Services.Configure<ApiBehaviorOptions>(option =>
{
    option.SuppressModelStateInvalidFilter = true;
});
builder.Services.AddStorage<LocalStorage>();
builder.Services.AddRepositoryService(builder.Configuration.GetConnectionString("MySQL"));
builder.Services.AddBusinessService(builder.Configuration["SaltKey"]);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins, policy =>
    {
        var origins = builder.Configuration["AllowedAccess:AllowOrigins"].Split(";");
        policy.WithOrigins(origins)
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
var fileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.WebRootPath, "resource"));
var requestPath = "/images";

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// Custom Middlewares
app.UseMiddleware<IPAddressControlMiddleware>();
app.UseGlobalExceptionMiddleware();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use(async (httpContext, next) =>
{
    httpContext.Response.Headers.Add("X-Frame-Options", "DENY");
    httpContext.Response.Headers.Add("X-Xss-Protection", "1; mode=block");
    httpContext.Response.Headers.Add("X-Content-Type-Options", "nosniff");
    httpContext.Response.Headers.Add(
        "Content-Security-Policy",
        "default-src 'self'; " +
        "img-src 'self' {your_awesome_url}; " +
        "font-src 'self'; " +
        "style-src 'self'; " +
        "script-src 'self' 'nonce-none-of-your-business-man' " +
        " 'nonce-none-of-your-business-man'; " +
        "frame-src 'self';" +
        "connect-src 'self';");
    httpContext.Response.Headers.Add("Referrer-Policy", "no-referrer");
    httpContext.Response.Headers.Add("Feature-Policy", "accelerometer 'none'; camera 'none';" +
                                                       " geolocation 'none'; gyroscope 'none'; " +
                                                       "magnetometer 'none'; microphone 'none'; " +
                                                       "payment 'none'; usb 'none'");
    await next();
});

app.UseHsts();

app.UseHttpsRedirection();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = fileProvider,
    RequestPath = requestPath
});

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
