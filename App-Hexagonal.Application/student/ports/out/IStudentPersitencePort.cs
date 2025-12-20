using App_Hexagonal.Application.Common.Persistence;
using App_Hexagonal.Domain.student.model;

namespace App_Hexagonal.Application.student.ports
{

    public interface IStudentPersistePort : IRepository<Student, Guid>
    {
        Task<IEnumerable<Student>> GetAllAsync();
    }
}