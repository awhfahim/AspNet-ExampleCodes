using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.SecurityTokenService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;

namespace FirstDemo.Domain.Exceptions
{
    //internal sealed class BadRequestExceptionHandler : IExceptionHandler
    //{
    //    private readonly ILogger<BadRequestExceptionHandler> _logger;

    //    public BadRequestExceptionHandler(ILogger<BadRequestExceptionHandler> logger)
    //    {
    //        _logger = logger;
    //    }

    //    public Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public async ValueTask<bool> TryHandleAsync(
    //        HttpContext httpContext,
    //        Exception exception,
    //        CancellationToken cancellationToken)
    //    {
    //        if (exception is not BadRequestException badRequestException)
    //        {
    //            return false;
    //        }

    //        _logger.LogError(
    //            badRequestException,
    //            "Exception occurred: {Message}",
    //            badRequestException.Message);

    //        var problemDetails = new ProblemDetails
    //        {
    //            Status = StatusCodes.Status400BadRequest,
    //            Title = "Bad Request",
    //            Detail = badRequestException.Message
    //        };

    //        httpContext.Response.StatusCode = problemDetails.Status.Value;

    //        await httpContext.Response
    //            .WriteAsJsonAsync(problemDetails, cancellationToken);

    //        return true;
    //    }

    //}

    //internal sealed class GlobalExceptionHandler : IExceptionHandler
    //{
    //    private readonly ILogger<GlobalExceptionHandler> _logger;

    //    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    //    {
    //        _logger = logger;
    //    }

    //    public Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public async ValueTask<bool> TryHandleAsync(
    //        HttpContext httpContext,
    //        Exception exception,
    //        CancellationToken cancellationToken)
    //    {
    //        _logger.LogError(
    //            exception, "Exception occurred: {Message}", exception.Message);

    //        var problemDetails = new ProblemDetails
    //        {
    //            Status = StatusCodes.Status500InternalServerError,
    //            Title = "Server error"
    //        };

    //        httpContext.Response.StatusCode = problemDetails.Status.Value;

    //        await httpContext.Response
    //            .WriteAsJsonAsync(problemDetails, cancellationToken);

    //        return true;
    //    }
    //}
}
