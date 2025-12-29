
# App-Hexagonal

Proyecto base multi-tenant en .NET con arquitectura hexagonal

---

## Descripción
Este proyecto es una base para aplicaciones multi-tenant desarrollada en .NET, siguiendo los principios de la arquitectura hexagonal (Ports & Adapters). Permite gestionar múltiples clientes (tenants) de forma segura y aislada, con soporte para usuarios, roles y autenticación JWT.

### Características principales
- **Multi-tenant:** Cada petición se asocia a un tenant mediante un middleware que filtra y propaga el contexto.
- **Middleware TenantContext:** Extrae el `tenant_id` del token JWT y lo propaga en el contexto de la aplicación.
- **Gestión de usuarios y roles:** Permite crear usuarios con roles personalizados (Admin, User, Cajero, etc.) por tenant.
- **Seguridad:** Autenticación y autorización con JWT e Identity.
- **Arquitectura hexagonal:** Separación clara entre dominio, aplicación, infraestructura y API.
- **Extensible:** Fácil de adaptar para nuevos casos de uso, entidades y reglas de negocio.

---

## Estructura del proyecto

```plaintext
App-Hexagonal.sln
├── App-Hexagonal.Api/                # API REST, controladores, middleware, configuración
│   ├── Controller/                   # Controladores HTTP
│   ├── Middleware/                   # Middlewares (TenantContext, ErrorHandling, etc.)
│   ├── user/tenant/student/          # Dtos, mapeos y lógica de presentación
│   └── Properties/                   # Configuración de lanzamiento
├── App-Hexagonal.Application/        # Lógica de aplicación, casos de uso, puertos
│   ├── Common/                       # Utilidades, seguridad, contexto de tenant
│   ├── user/tenant/student/          # Ports, UseCases
│   └── DependencyInjection.cs        # Inyección de dependencias
├── App-Hexagonal.Domain/             # Entidades de dominio, modelos, excepciones
│   ├── user/tenant/student/          # Modelos de dominio
│   └── Common/Error/                 # Entidades base y errores
├── App-Hexagonal.Infrastructura/     # Implementaciones de puertos, persistencia, mapeos
│   ├── data/identity/tenant/         # Adaptadores y repositorios
│   ├── Migrations/                   # Migraciones de base de datos
│   └── DependencyInjection.cs        # Inyección de dependencias
├── docker/                           # Archivos para despliegue con Docker
├── docs/                             # Documentación técnica y diagramas
│   ├── README_MIDDLEWARE_TENANTCONTEXT.md
│   ├── hexagonal-architecture.puml
│   └── student-request-flow.puml
└── Readme.md                         # Documentación general del proyecto
```

---

## Diagrama de arquitectura

Puedes encontrar el diagrama de arquitectura hexagonal en `docs/hexagonal-architecture.puml`.

---

## ¿Cómo funciona el flujo multi-tenant?
1. El usuario se autentica y recibe un JWT con el claim `tenant_id`.
2. El middleware `TenantContextMiddleware` extrae el `tenant_id` y lo propaga en el contexto.
3. Los casos de uso y servicios acceden al contexto para operar bajo el tenant correcto.
4. Los usuarios pueden ser creados por el tenant con roles personalizados.
5. Toda la lógica de negocio y persistencia respeta el aislamiento por tenant.

---

## Seguridad
- Autenticación JWT.
- Roles y claims en el token.
- Middleware para validación y propagación del contexto de seguridad.

---

## Extensión y personalización
- Puedes agregar nuevos roles, entidades y casos de uso siguiendo la estructura hexagonal.
- El contexto de tenant puede extenderse para guardar más información relevante.

---

## Documentación adicional
- [README_MIDDLEWARE_TENANTCONTEXT.md](docs/README_MIDDLEWARE_TENANTCONTEXT.md): Detalles del middleware de contexto de tenant.
- Diagramas en `docs/` para flujos y arquitectura.

---

> Actualiza este README conforme evolucione el proyecto y se agreguen nuevas funcionalidades.