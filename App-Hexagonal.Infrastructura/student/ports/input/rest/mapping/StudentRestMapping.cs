using App_Hexagonal.Domain.student.model;
using App_Hexagonal.Infrastructura.student.ports.input.rest.model.request;
using Mapster;

namespace App_Hexagonal.Infrastructura.student.ports.input.rest.mapping
{
    public static class StudentRestMapping
    {
        public static Student ToDomain(this StudentCreateRequest request)
        {
            // Si necesitas lógica personalizada, puedes mapear manualmente aquí
            return new Student(
                0, // El id se genera en persistencia
                request.FileName,
                request.LastName,
                request.Age,
                request.Adress
            );
        }
    }
}