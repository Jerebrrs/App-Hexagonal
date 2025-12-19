

using App_Hexagonal.Api.student.Dtos.request;
using App_Hexagonal.Application.student.useCase.command;
using App_Hexagonal.Domain.student.model;
using App_Hexagonal.student.Dtos.response;

namespace App_Hexagonal.Api.student.mapping
{
    public static class StudentRestMapping
    {
        public static CreateStudentCommand ToCommand(this StudentCreateRequest request)
            => new(
                request.FileName,
                request.LastName,
                request.Age,
                request.Adress
            );

        public static UpdateStudentCommand ToCommand(this StudentCreateRequest request, Guid id)
            => new(
                id,
                request.FileName,
                request.LastName,
                request.Age,
                request.Adress
            );
        public static StudentResponse ToResponse(this Student student)
 => new(
     student.Id,
     student.FileName,
     student.LastName,
     student.Age,
     student.Adress
 );
    }
}