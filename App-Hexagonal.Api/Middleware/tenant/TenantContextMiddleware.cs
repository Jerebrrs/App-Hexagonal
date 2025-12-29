using App_Hexagonal.Application.Common.security;
using App_Hexagonal.Application.Common.tenant;

namespace App_Hexagonal.Api.Middleware.tenant;

public class TenantContextMiddleware
{
    private readonly RequestDelegate _next;
    public TenantContextMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task InvokeAsync(HttpContext context, HttpTenantContext tenantContext)
    {
        var tenantClaim = context.User?.FindFirst(CustomClaims.TenantId);

        if (tenantClaim != null && Guid.TryParse(tenantClaim.Value, out var tenantId))
        {
            tenantContext.SetTenant(tenantId);
        }
        await _next(context);
    }
}
