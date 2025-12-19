
using App_Hexagonal.Application.Common.UseCase;

using App_Hexagonal.Application.student.ports;
using App_Hexagonal.Application.student.query;
using App_Hexagonal.Domain.student.model;

namespace App_Hexagonal.Application.student.useCase;

public class GetStudentByIdUseCase : IUseCase<GetStudentByIdQuery, Student?>
{

    private readonly IStudentPersistePort _repository;

    public GetStudentByIdUseCase(IStudentPersistePort repository)
    {
        _repository = repository;
    }
    public async Task<Student?> ExecuteAsync(GetStudentByIdQuery request)
    {
        return await _repository.GetByIdAsync(request.Id);
    }
}
