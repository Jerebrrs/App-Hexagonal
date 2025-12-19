
using App_Hexagonal.Application.Common.UseCase;
using App_Hexagonal.Application.student.ports;
using App_Hexagonal.Application.student.query;
using App_Hexagonal.Domain.student.model;

namespace App_Hexagonal.Application.student.useCase;

public class GetAllStudentsUseCase : IUseCase<GetAllStudentsQuery, IEnumerable<Student>>
{
    private readonly IStudentPersistePort _repository;

    public GetAllStudentsUseCase(IStudentPersistePort repository)
    {
        _repository = repository;
    }
    public async Task<IEnumerable<Student>> ExecuteAsync(GetAllStudentsQuery _)
    {
        return await _repository.GetAllAsync();
    }
}
