using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using HhGlobal.TotalCostCalculator.API.IoC;
using HhGlobal.TotalCostCalculator.API.Middleware;
using HhGlobal.TotalCostCalculator.BLL.IoC;
using HhGlobal.TotalCostCalculator.BLL.Common;

var builder = WebApplication.CreateBuilder(args);

//Add console log provider
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

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

builder.Services.Configure<Configuration>(
    builder.Configuration.GetSection("CostCalculations"));

//Register AutoMapper as mapping framework
builder.Services.AddAutoMapper(typeof(Program));

//Register Autofac service provider factory
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

//Register Autofac modules
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new ApiModule());
    builder.RegisterModule(new BllModule());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Register global error handler
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
