using App_Hexagonal.Api.student.Dtos.request;
using App_Hexagonal.Domain.student.model;

namespace App_Hexagonal.Api.student.mapping
{
    public static class StudentRestMapping
    {
        public static Student ToDomain(this StudentCreateRequest request)
        {

            return new Student(
                0,
                request.FileName,
                request.LastName,
                request.Age,
                request.Adress
            );
        }
    }
}