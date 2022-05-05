using System.Reflection;
using DevBlog.Repository;
using DevBlog.Service;
using DevBlog.Service.ValidationRules;
using DevBlog.WebAPI.Filters;
using DevBlog.WebAPI.Middlewares;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

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

builder.Services.AddRepositoryService(builder.Configuration.GetConnectionString("MySQL"));
builder.Services.AddBusinessService();

builder.Services.AddScoped<CheckExistIdFilter>();

var app = builder.Build();

app.UseGlobalExceptionMiddleware();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
