using Autofac;
using Autofac.Extensions.DependencyInjection;
using DevBlog.Repository;
using DevBlog.Service;
using DevBlog.Service.DependencyResolvers.Autofac;
using DevBlog.WebAPI.Filters;
using DevBlog.WebAPI.Middlewares;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacServiceModule()));

// Add services to the container.
builder.Services.AddControllers(opts => opts.Filters.Add(new ValidationFilter()))
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining(typeof(ServiceRegistration)));
builder.Services.Configure<ApiBehaviorOptions>(option =>
{

    option.SuppressModelStateInvalidFilter = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Data Access layer registration
builder.Services.AddRepositoryService(builder.Configuration.GetConnectionString("MySQL"));
// Business layer registration
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

app.UseStaticFiles();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
