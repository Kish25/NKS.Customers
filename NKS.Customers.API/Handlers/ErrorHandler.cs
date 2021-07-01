//https://github.com/domaindrivendev/Swashbuckle.WebApi/issues/969

using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.SecurityTokenService;
using Newtonsoft.Json;
using NKS.Customers.Core.Exceptions;

namespace NKS.Customers.API.Handlers
{
    public class ErrorHandler
    {
        private readonly RequestDelegate       next;
        private readonly IHostingEnvironment   _env;
        private readonly ILogger<ErrorHandler> _logger;

        public ErrorHandler(RequestDelegate next, ILogger<ErrorHandler> logger, IHostingEnvironment env)
        {
            this.next = next;
            _env = env;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;


            var result = JsonConvert.SerializeObject(new
                { Code = code, Error = exception.Message, exception.StackTrace });

            if (exception is BadRequestException)
            {
                code = HttpStatusCode.BadRequest;
                result = exception.Message;

                _logger.LogInformation($"Bad Request: {exception.Message}");
            }
            else if (exception is ResourceNotFoundException)
            {
                code = HttpStatusCode.NotFound;
                result = exception.Message;

                _logger.LogInformation(exception.Message);
            }
            else if (exception is UnauthorizedAccessException) //UnauthorizedException
            {
                code = HttpStatusCode.Unauthorized;
                result = exception.Message;

                _logger.LogInformation(exception.Message);
            }
            else
            {
                code = HttpStatusCode.Unauthorized;
                result = exception.Message;

                _logger.LogCritical(new EventId(666, "TheAntiChristCometh"), exception, exception.Message);
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

#if DEBUG
            //only show in debug during development
            if (_env.IsDevelopment())
                return context.Response.WriteAsync(result);
#endif

            return context.Response.WriteAsync("");
        }
    }

    public static class ErrorHandlerExtension
    {
        public static IApplicationBuilder UseErrorHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandler>();
        }
    }
}
