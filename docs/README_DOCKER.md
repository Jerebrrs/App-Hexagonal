# Entorno de desarrollo con Docker y SQL Server

Este proyecto incluye un archivo `docker-compose.yml` listo para levantar una instancia de SQL Server 2022 en modo Developer, ideal para desarrollo local.

## Requisitos
- Docker y Docker Compose instalados

## Pasos para iniciar el entorno

1. **Levanta el contenedor de SQL Server:**
   ```bash
   docker compose up -d
   ```
   Esto creará y levantará el contenedor con SQL Server en el puerto 1433.

2. **Conexión a la base de datos:**
   - **Host:** `localhost`
   - **Puerto:** `1433`
   - **Usuario:** `sa`
   - **Contraseña:** `YourStrong!Passw0rd` (puedes cambiarla en el docker-compose)

3. **Crear una base de datos inicial:**
   Puedes conectarte usando SQL Server Management Studio, Azure Data Studio, DBeaver, o la CLI de `sqlcmd`:
   ```bash
   docker exec -it sqlserver /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P YourStrong!Passw0rd
   ```
   Y luego ejecutar:
   ```sql
   CREATE DATABASE AppHexagonal;
   GO
   ```

4. **Persistencia de datos:**
   Los datos se guardan en el volumen `sqlserver_data`, por lo que no se perderán al reiniciar el contenedor.

## Notas
- La imagen utilizada es la oficial de Microsoft para SQL Server 2022 Developer.
- Cambia la contraseña en producción.
- El contenedor se reiniciará automáticamente si falla.

---

Para más detalles sobre la arquitectura hexagonal y el flujo de peticiones, revisa los otros archivos en la carpeta `docs/`.
