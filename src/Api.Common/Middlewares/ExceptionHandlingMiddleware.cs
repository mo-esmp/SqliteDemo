using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Api.Common.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHostingEnvironment _environment;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        private readonly ObjectResultExecutor _objectResultExecutor;

        public ExceptionHandlingMiddleware(
            RequestDelegate next,
            IHostingEnvironment environment,
            ILogger<ExceptionHandlingMiddleware> logger,
            ObjectResultExecutor objectResultExecutor
            )
        {
            _next = next;
            _environment = environment;
            _logger = logger;
            _objectResultExecutor = objectResultExecutor;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(0, ex, $"An unhandled exception has occurred, {ex.Message}");
                //EventLog.WriteEntry("Application", $"An unhandled exception has occurred, {ex.Message}", EventLogEntryType.Error);

                //context.Response.Headers.Clear();
                var json = new JsonErrorResponse { Messages = new[] { "An error occurred.Try it again." } };

                if (_environment.IsDevelopment())
                {
                    json.DeveloperMessage = ex;
                }

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.Clear();
                await _objectResultExecutor.ExecuteAsync(new ActionContext { HttpContext = context }, new InternalServerErrorObjectResult(json));
            }
        }

        private class JsonErrorResponse
        {
            public string[] Messages { get; set; }

            public object DeveloperMessage { get; set; }
        }
    }

    public class InternalServerErrorObjectResult : ObjectResult
    {
        public InternalServerErrorObjectResult(object error)
            : base(error)
        {
            StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}