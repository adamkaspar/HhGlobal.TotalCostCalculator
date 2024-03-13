using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using HhGlobal.TotalCostCalculator.API.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Total Cost Calculator Api",
        Description = "Api to support total cost calculations"
    });
});

//Register AutoMapper as mapping framework
builder.Services.AddAutoMapper(typeof(Program));

//Register Autofac service provider factory
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

//Register Autofac modules
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new ApiModule()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
