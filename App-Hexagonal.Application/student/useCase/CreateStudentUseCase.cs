using App_Hexagonal.Application.Common.UseCase;
using App_Hexagonal.Application.student.ports;
using App_Hexagonal.Application.student.useCase.command;
using App_Hexagonal.Domain.student.model;

namespace App_Hexagonal.Application.student.useCase
{
    public class CreateStudentUseCase : IUseCase<CreateStudentCommand, Student>
    {
        private readonly IStudentPersistePort _repository;
        public CreateStudentUseCase(IStudentPersistePort repository)
        {
            _repository = repository;
        }
        public async Task<Student> ExecuteAsync(CreateStudentCommand request)
        {
            var student = new Student(request.Name, request.LastName, request.Age, request.Adress);
            await _repository.AddAsync(student);
            return student;
        }
    }
}