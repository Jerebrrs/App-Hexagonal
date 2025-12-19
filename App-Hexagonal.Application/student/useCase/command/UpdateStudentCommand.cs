namespace App_Hexagonal.Application.student.useCase.command;

public record class UpdateStudentCommand(Guid Id,
    string Name,
    string LastName,
    int Age,
    string Adress);