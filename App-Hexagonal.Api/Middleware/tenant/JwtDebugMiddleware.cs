using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App_Hexagonal.Api.Middleware.tenant
{
    public class JwtDebugMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtDebugMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Headers.TryGetValue("Authorization", out var auth))
            {
                Console.WriteLine($"[JWT DEBUG] Authorization header: {auth}");
            }
            else
            {
                Console.WriteLine("[JWT DEBUG] NO Authorization header");
            }

            await _next(context);
        }
    }

}