using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_Core___Avoiding_Large_Controllers.MiddleWare
{
    public static class MiddleWareExtensions
    {
        public static IApplicationBuilder UserCustomeExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleWare>();
        }
    }
}
