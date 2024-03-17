using System.Net;
using HhGlobal.TotalCostCalculator.API.Dto.Exceptions;

namespace HhGlobal.TotalCostCalculator.API.Middleware;


public class ExceptionHandlingMiddleware
{
    RequestDelegate Next { get; }

    ILogger<ExceptionHandlingMiddleware> Logger { get; }

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    => (Next, Logger) = (next, logger);

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await Next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var correlationId = Guid.NewGuid();

        Logger.LogError(exception, $"CorrelationId: {correlationId}. An unexpected error occurred.");

        var response = exception switch
        {
            ApplicationException _ => new ExceptionDto { CorrelationId = correlationId, StatusCode = HttpStatusCode.BadRequest, Message = "Application exception occurred." },
            _ => new ExceptionDto { CorrelationId = correlationId, StatusCode = HttpStatusCode.InternalServerError, Message = "Internal server error. Please retry later." }
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)response.StatusCode;

        await context.Response.WriteAsJsonAsync(response);
    }
}
