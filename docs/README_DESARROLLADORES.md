# Guía para Nuevos Desarrolladores: Arquitectura Hexagonal en App-Hexagonal

Este documento explica cómo trabajar en este proyecto siguiendo la arquitectura hexagonal, usando el modelo **Student** como ejemplo. Aquí aprenderás cómo se estructura el código, el propósito de cada capa y las mejores prácticas para contribuir.

---

## Estructura General del Proyecto

- **Domain**: Lógica de negocio y modelos puros.
- **Application**: Casos de uso y puertos (interfaces) que definen contratos.
- **Infrastructure**: Implementaciones concretas (adaptadores), como persistencia en base de datos.
- **API**: Exposición de la aplicación al exterior (controladores, endpoints).

---

## Ejemplo: Student

### 1. Dominio (`App-Hexagonal.Domain`)
- **Ubicación:** `App-Hexagonal.Domain/student/model/Student.cs`
- **Propósito:** Define la entidad principal y sus reglas de negocio.
- **Ejemplo:**
  ```csharp
  public class Student : BaseEntity {
      public string Name { get; set; }
      // ... otras propiedades y lógica de negocio
  }
  ```
- **Importante:** Aquí no hay dependencias a frameworks ni a otras capas.

### 2. Application (Puertos y Casos de Uso)
- **Ubicación:**
  - Puertos: `App-Hexagonal.Application/student/ports/IStudentRepository.cs`
  - Casos de uso: `App-Hexagonal.Application/student/useCase/CreateStudentUseCase.cs`
- **Propósito:**
  - **Puertos:** Definen interfaces para interactuar con el dominio (ej: guardar, buscar estudiantes).
  - **Casos de uso:** Orquestan la lógica de negocio usando los puertos.
- **Ejemplo de Puerto:**
  ```csharp
  public interface IStudentRepository {
      void Add(Student student);
      Student GetById(Guid id);
      // ... otros métodos
  }
  ```
- **Ejemplo de Caso de Uso:**
  ```csharp
  public class CreateStudentUseCase {
      private readonly IStudentRepository _repo;
      public CreateStudentUseCase(IStudentRepository repo) {
          _repo = repo;
      }
      public void Execute(Student student) {
          // Validaciones y lógica de negocio
          _repo.Add(student);
      }
  }
  ```

### 3. Mapping entre Capas
- **¿Por qué se hace mapping?**
  - Para desacoplar los modelos de dominio de los DTOs (objetos de transferencia de datos) usados en la API o en la infraestructura.
  - Permite evolucionar el dominio sin afectar otras capas.
- **Dónde:**
  - En la API: para convertir entre DTOs y modelos de dominio.
  - En Infrastructure: para convertir entre entidades de base de datos y modelos de dominio.

### 4. Infrastructure (Adaptadores)
- **Ubicación:** `App-Hexagonal.Infrastructura/student/persistence/StudentRepository.cs`
- **Propósito:** Implementa los puertos definidos en Application, usando tecnologías concretas (ej: Entity Framework, SQL, etc).
- **Ejemplo:**
  ```csharp
  public class StudentRepository : IStudentRepository {
      // Implementación usando Entity Framework
  }
  ```
- **Importante:** Aquí se maneja la persistencia, servicios externos, etc.

### 5. API (Controladores)
- **Ubicación:** `App-Hexagonal.Api/Controller/StudentController.cs`
- **Propósito:** Expone endpoints HTTP para interactuar con la aplicación.
- **Ejemplo:**
  ```csharp
  [ApiController]
  [Route("api/[controller]")]
  public class StudentController : ControllerBase {
      private readonly CreateStudentUseCase _useCase;
      // ... Métodos para manejar requests
  }
  ```

---

## Buenas Prácticas
- Mantén el dominio libre de dependencias externas.
- Define puertos en Application y adáptalos en Infrastructure.
- Usa mapping para desacoplar modelos.
- Los casos de uso deben ser orquestadores, no implementaciones técnicas.
- La API solo debe exponer la funcionalidad, no contener lógica de negocio.

---

## ¿Por qué esta arquitectura?
- Facilita el testeo y la mantenibilidad.
- Permite cambiar tecnologías externas sin afectar el dominio.
- Favorece la escalabilidad y la claridad en la organización del código.

---

## ¿Cómo agregar una nueva funcionalidad?
1. Define el modelo en Domain.
2. Crea el puerto y el caso de uso en Application.
3. Implementa el adaptador en Infrastructure.
4. Expón la funcionalidad en la API.
5. Realiza los mapeos necesarios entre DTOs y modelos.

---

¡Bienvenido al equipo! Si tienes dudas, revisa este documento o consulta con el equipo de arquitectura.