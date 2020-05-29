using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Demo.HR.Models.Common;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Demo.HR.API.Bootstrapper
{
    public class GlobalExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = (int)HttpStatusCode.InternalServerError;
            if (exception is CustomException)
                code = (int)HttpStatusCode.BadRequest;

            var result = new
            {
                errors = new Dictionary<string, string>(),
                title = "Exception in the API",
                detail = "An exception occurred",
                status = code,
                type = string.Empty
            };
            result.errors.Add("exception", exception.Message);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = code;
            return context.Response.WriteAsync(JsonConvert.SerializeObject(result));
        }
    }
}
