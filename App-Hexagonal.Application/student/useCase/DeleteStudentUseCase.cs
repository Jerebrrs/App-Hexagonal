using System;
using System.Diagnostics.Metrics;
using App_Hexagonal.Application.Common.UseCase;
using App_Hexagonal.Application.student.ports;
using App_Hexagonal.Application.student.useCase.command;
using App_Hexagonal.Domain.student.model;

namespace App_Hexagonal.Application.student.useCase;

public class DeleteStudentUseCase : IUseCase<DeleteStudentCommand, bool>
{
    private readonly IStudentPersistePort _repository;
    public DeleteStudentUseCase(IStudentPersistePort repository)
    {
        _repository = repository;
    }
    public async Task<bool> ExecuteAsync(DeleteStudentCommand request)
    {
        await _repository.DeleteAsync(request.Id);
        return true;

    }
}
