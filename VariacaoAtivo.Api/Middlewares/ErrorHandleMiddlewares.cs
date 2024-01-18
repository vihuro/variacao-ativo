using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;

namespace VariacaoAtivo.Api_.Middlewares
{
    /// <summary>
    /// Centralização de erros no midleware.
    /// </summary>
    public class ErrorHandleMiddlewares
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="next"></param>
        public ErrorHandleMiddlewares(RequestDelegate next)
        {
            _next = next;
        }/// <summary>
        /// 
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {

                await HandleExceptionAsync(httpContext, ex);
            };
        }
        private static Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            var response = httpContext.Response;
            response.ContentType = "application/json";

            var statusCode = HttpStatusCode.BadRequest;

            if (exception.HResult == 404)
            {
                statusCode = HttpStatusCode.NotFound;
            }

            var trace = new StackTrace(exception, true);


            var separetString = exception.Message.Split('\n').Where(x => x != "").ToList();

            var path = string.Empty;
            var column = string.Empty;
            var line = string.Empty;

            for (var i = 0; i < trace.FrameCount; i++)
            {
                if (trace.GetFrame(i).GetFileLineNumber() != 0)
                {
                    path = trace.GetFrame(i).GetFileName();
                    line = trace.GetFrame(i).GetFileColumnNumber().ToString();
                    break;
                }
            }


            var responseItem = new
            {
                statusCode = statusCode.ToString(),
                line = line,
                path = path,
                separetString = separetString
            };


            httpContext.Response.StatusCode = Convert.ToInt32(statusCode);

            var result = JsonConvert.SerializeObject(responseItem);
            httpContext.Response.ContentType = "application/json";

            return httpContext.Response.WriteAsync(result);

        }

    }
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandleMiddlewares>();
        }
    }
}
