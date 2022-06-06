using DevBlog.Repository;
using DevBlog.Service;
using DevBlog.Service.Utilities.Storage.LocalStorage;
using DevBlog.WebAPI.Filters;
using DevBlog.WebAPI.Middlewares;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(opts => opts.Filters.Add(new ValidationFilter()))
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining(typeof(DevBlog.Service.ServiceRegistration)));
builder.Services.Configure<ApiBehaviorOptions>(option =>
{
    option.SuppressModelStateInvalidFilter = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
builder.Services.AddStorage<LocalStorage>();

var fileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.WebRootPath, "resource"));
var requestPath = "/images";

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
