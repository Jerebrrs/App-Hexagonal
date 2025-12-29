# Middleware TenantContext

Este documento explica el flujo y funcionamiento del circuito de `TenantContextMiddleware` en la aplicación, para futuros desarrolladores.

## ¿Qué es TenantContextMiddleware?
`TenantContextMiddleware` es un middleware que se encarga de extraer el identificador del tenant (organización/cliente) desde el token JWT de la petición HTTP y propagarlo en el contexto de la aplicación.

## Flujo de ejecución
1. **Intercepta la petición HTTP**: El middleware se ejecuta en cada request.
2. **Obtiene el claim de TenantId**: Busca el claim `tenant_id` (definido en `CustomClaims.TenantId`) en el token JWT del usuario autenticado.
3. **Valida y setea el TenantId**: Si el claim existe y es un GUID válido, lo asigna al contexto de tenant (`ITenantContext`).
4. **Propaga el contexto**: El resto de la aplicación puede acceder al `TenantId` y saber si la petición está asociada a un tenant válido.
5. **Continúa el pipeline**: Llama al siguiente middleware/controlador.

## Código relevante
- **TenantContextMiddleware**: Implementa la lógica de extracción y propagación del tenant.
- **ITenantContext**: Interfaz que define el contrato para el contexto de tenant.
- **HttpTenantContext**: Implementación concreta de `ITenantContext`.

## Ejemplo de uso
```csharp
public async Task InvokeAsync(HttpContext context, ITenantContext tenantContext)
{
    var tenantClaim = context.User?.FindFirst(CustomClaims.TenantId);
    if (tenantClaim != null && Guid.TryParse(tenantClaim.Value, out var tenantId))
    {
        tenantContext.SetTenant(tenantId);
        _logger.LogInformation($"Tenant seteado: {tenantId}");
    }
    else
    {
        _logger.LogWarning("No se encontró tenant_id en el token o es inválido");
    }
    await _next(context);
}
```

## Consideraciones
- Si el token no contiene el claim `tenant_id` o es inválido, el contexto no tendrá un tenant asociado (`HasTenant` será `false`).
- Es fundamental para la seguridad multi-tenant, ya que permite que los servicios y casos de uso validen y operen bajo el tenant correcto.

## Extensión
Puedes extender el contexto para guardar más información del tenant si lo necesitas (nombre, configuración, etc.), modificando la implementación de `ITenantContext` y su uso en el middleware.

---

> Actualiza este documento si el flujo del middleware cambia o se agregan nuevas validaciones.
