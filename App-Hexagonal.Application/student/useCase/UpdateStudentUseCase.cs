
using App_Hexagonal.Application.Common.UseCase;
using App_Hexagonal.Application.student.ports;
using App_Hexagonal.Application.student.useCase.command;
using App_Hexagonal.Domain.student.model;

namespace App_Hexagonal.Application.student.useCase;

public class UpdateStudentUseCase : IUseCase<UpdateStudentCommand, Student>
{
    private readonly IStudentPersistePort _repository;
    public UpdateStudentUseCase(IStudentPersistePort repository)
    {
        _repository = repository;
    }
    public async Task<Student> ExecuteAsync(UpdateStudentCommand request)
    {
        var student = await _repository.GetByIdAsync(request.Id);
        if (student is null) throw new AppDomainUnloadedException("Student Not Found");

        student.Update(request.Name, request.LastName, request.Age, request.Adress);
        await _repository.UpdateAsync(student);
        return student;
    }
}
