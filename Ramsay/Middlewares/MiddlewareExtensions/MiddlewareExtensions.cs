using Microsoft.AspNetCore.Builder;
using Ramsay.Middlewares;

namespace Ramsay.Middlewares.MiddlewareExtensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseDataMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DataMiddleware>();
        }
    }
}