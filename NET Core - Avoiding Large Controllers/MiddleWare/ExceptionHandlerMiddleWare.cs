using Microsoft.AspNetCore.Http;
using NetCoreAvodingLargeControllers.Application.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace NET_Core___Avoiding_Large_Controllers.MiddleWare
{
    public class ExceptionHandlerMiddleWare
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleWare(RequestDelegate next)
        {
            _next = next;
        }


        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {

                await ConvertException(context, ex);
            }
        }

        private Task ConvertException(HttpContext context, Exception ex)
        {
            HttpStatusCode httpsStatusCode = HttpStatusCode.InternalServerError;

            context.Response.ContentType = "application/json";

            var result = string.Empty;

            switch (ex)
            {
                case ModelValidationException validationException:
                    httpsStatusCode = HttpStatusCode.BadRequest;
                    result = JsonConvert.SerializeObject(validationException.ValdationErrors);
                    break;
                case ModelNotFoundException notFoundException:
                    httpsStatusCode = HttpStatusCode.NotFound;
                    break;
                default:
                    httpsStatusCode = HttpStatusCode.BadRequest;
                    break;
            }

            context.Response.StatusCode = (int)httpsStatusCode;

            if (result == string.Empty)
            {
                result = JsonConvert.SerializeObject(new { error = ex.Message });

            }

            return context.Response.WriteAsync(result);
        }
    }
}
