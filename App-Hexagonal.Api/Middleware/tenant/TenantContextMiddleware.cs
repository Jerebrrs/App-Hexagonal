using App_Hexagonal.Application.Common.security;
using App_Hexagonal.Application.Common.tenant;
using Microsoft.Extensions.Logging;

namespace App_Hexagonal.Api.Middleware.tenant;

public class TenantContextMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<TenantContextMiddleware> _logger;

    public TenantContextMiddleware(RequestDelegate next, ILogger<TenantContextMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, ITenantContext tenantContext)
    {
        var tenantClaim = context.User?.FindFirst(CustomClaims.TenantId);

        if (tenantClaim != null && Guid.TryParse(tenantClaim.Value, out var tenantId))
        {
            tenantContext.SetTenant(tenantId);
            _logger.LogInformation("Tenant seteado: {TenantId}", tenantId);
        }
        else
        {
            _logger.LogWarning("No se encontró tenant_id en el token o es inválido");
        }

        await _next(context);
    }

}
